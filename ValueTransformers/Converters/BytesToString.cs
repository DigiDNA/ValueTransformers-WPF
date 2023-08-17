/*******************************************************************************
 * The MIT License (MIT)
 * 
 * Copyright (c) 2021 DigiDNA - www.imazing.com
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 ******************************************************************************/

using System;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace ValueTransformers
{
    [ MarkupExtensionReturnType( typeof( IValueConverter ) ) ]
    [ ValueConversion( typeof( ulong ), typeof( String ) ) ]
    public class BytesToString: MarkupExtension, IValueConverter
    {
        public enum Prefix
        {
            Binary,
            Decimal
        }
        
        public static Func< ulong, Prefix, string >? CustomFormatter = null;

        public static string StringFromBytes( ulong bytes, Prefix prefix = Prefix.Binary )
        {
            if( CustomFormatter is Func< ulong, Prefix, string > formatter )
            {
                return formatter( bytes, prefix );
            }

            ulong p = ( ulong )( ( prefix == Prefix.Binary ) ? 1024 : 1000 );

            if( bytes < p )
            {
                return bytes + " bytes";
            }
            else if( bytes < p * p )
            {
                return ( ( double )bytes / p ).ToString( "0.00 KB", System.Globalization.CultureInfo.InvariantCulture );
            }
            else if( bytes < p * p * p )
            {
                return ( ( double )bytes / p / p ).ToString( "0.00 MB", System.Globalization.CultureInfo.InvariantCulture );
            }
            else if( bytes < p * p * p * p )
            {
                return ( ( double )bytes / p / p / p ).ToString( "0.00 GB", System.Globalization.CultureInfo.InvariantCulture );
            }

            return ( ( double )bytes / p / p / p / p ).ToString( "0.00 TB", System.Globalization.CultureInfo.InvariantCulture );
        }

        public object? Convert( object? value, Type targetType, object? parameter, System.Globalization.CultureInfo? culture )
        {
            Helper.CheckTargetType( targetType, typeof( String ) );
            
            if( value == null )
            {
                return null;
            }

            ulong bytes = 0;
            
                 if( value is sbyte  sb ) { bytes = ( ulong )sb; }
            else if( value is byte    b ) { bytes = b; }
            else if( value is char    c ) { bytes = c; }
            else if( value is short   s ) { bytes = ( ulong )s; }
            else if( value is ushort us ) { bytes = us; }
            else if( value is int     i ) { bytes = ( ulong )i; }
            else if( value is uint   ui ) { bytes = ui; }
            else if( value is long    l ) { bytes = ( ulong )l; }
            else if( value is ulong  ul ) { bytes = ul; }

            Prefix prefix = ( parameter is string p && p.ToLower() == "decimal" ) ? Prefix.Decimal : Prefix.Binary;
            
            return StringFromBytes( bytes, prefix );
        }

        public object? ConvertBack( object? value, Type targetType, object? parameter, System.Globalization.CultureInfo? culture )
        {
            throw new NotSupportedException();
        }

        private static readonly Lazy< BytesToString > Converter = new Lazy< BytesToString >( () => new BytesToString() );

        public override object ProvideValue( IServiceProvider serviceProvider )
        {
            return Converter.Value;
        }
    }
}
