/*******************************************************************************
 * Copyright (c) 2019, DigiDNA
 * All rights reserved
 * 
 * Unauthorised copying of this copyrighted work, via any medium is strictly
 * prohibited.
 * Proprietary and confidential.
 ******************************************************************************/

using System;
using System.Windows.Data;
using System.Windows.Markup;

namespace ValueTransformers
{
    [ MarkupExtensionReturnType( typeof( IValueConverter ) ) ]
    [ ValueConversion( typeof( object ), typeof( bool ) ) ]
    public class NegateBoolean: MarkupExtension, IValueConverter
    {
        public object Convert( object? value, Type targetType, object? parameter, System.Globalization.CultureInfo? culture )
        {
            if( value is bool b )
            {
                return b == false;
            }

            throw new ArgumentException( "Invalid value", nameof( value ) );
        }

        public object ConvertBack( object? value, Type targetType, object? parameter, System.Globalization.CultureInfo? culture )
        {
            if( value is bool b )
            {
                return b == false;
            }

            throw new ArgumentException( "Invalid value", nameof( value ) );
        }

        private static readonly Lazy< NegateBoolean > Converter = new Lazy< NegateBoolean >( () => new NegateBoolean() );

        public override object ProvideValue( IServiceProvider serviceProvider )
        {
            return Converter.Value;
        }
    }
}
