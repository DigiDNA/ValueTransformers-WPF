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
    public class IsZero: MarkupExtension, IValueConverter
    {
        public object Convert( object? value, Type targetType, object? parameter, System.Globalization.CultureInfo? culture )
        {
            return Helper.IsZero( value );
        }

        public object? ConvertBack( object? value, Type targetType, object? parameter, System.Globalization.CultureInfo? culture )
        {
            throw new NotSupportedException();
        }

        private static IsZero? Converter
        {
            get;
            set;
        }

        public override object ProvideValue( IServiceProvider serviceProvider )
        {
            if( Converter == null )
            {
                Converter = new IsZero();
            }

            return Converter;
        }
    }
}
