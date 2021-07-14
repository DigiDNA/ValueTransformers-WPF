/*******************************************************************************
 * Copyright (c) 2021, DigiDNA
 * All rights reserved
 * 
 * Unauthorised copying of this copyrighted work, via any medium is strictly
 * prohibited.
 * Proprietary and confidential.
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
        public static Func< ulong, String >? CustomFormatter = null;
        
        public object? Convert( object? value, Type targetType, object? parameter, System.Globalization.CultureInfo? culture )
        {
            Helper.CheckTargetType( targetType, typeof( String ) );
            
            if( value == null )
            {
                return null;
            }
            
            ulong bytes = 0
            
                 if( value is sbyte  sb ) { bytes = sb; }
            else if( value is byte    b ) { bytes =  b; }
            else if( value is char    c ) { bytes =  c; }
            else if( value is uchar  uc ) { bytes = uc; }
            else if( value is short   s ) { bytes =  s; }
            else if( value is ushort us ) { bytes = us; }
            else if( value is int     i ) { bytes =  i; }
            else if( value is uint   ui ) { bytes = ui; }
            else if( value is long    l ) { bytes =  l; }
            else if( value is ulong  ul ) { bytes = ul; }
            
            if( CustomFormatter is Func< ulong, String > formatter )
            {
                return formatter( bytes );
            }
            
            return null;
        }

        public object? ConvertBack( object? value, Type targetType, object? parameter, System.Globalization.CultureInfo? culture )
        {
            throw new NotSupportedException();
        }

        private static readonly Lazy< BoolToVisibility > Converter = new Lazy< BoolToVisibility >( () => new BoolToVisibility() );

        public override object ProvideValue( IServiceProvider serviceProvider )
        {
            return Converter.Value;
        }
    }
}
