/*******************************************************************************
 * Copyright (c) 2019, DigiDNA
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
    [MarkupExtensionReturnType( typeof( IValueConverter ) )]
    [ValueConversion( typeof( string ), typeof( string ) )]
    public class UppercaseString: MarkupExtension, IValueConverter
    {
        public object? Convert( object? value, Type targetType, object? parameter, System.Globalization.CultureInfo? culture )
        {
            Helper.CheckTargetType( targetType, typeof( string ) );

            if( value is string str )
            {
                return str.ToUpper();
            }

            return null;
        }

        public object ConvertBack( object? value, Type targetType, object? parameter, System.Globalization.CultureInfo? culture )
        {
            throw new NotSupportedException();
        }

        private static readonly Lazy< UppercaseString > Converter = new Lazy< UppercaseString >( () => new UppercaseString() );

        public override object ProvideValue( IServiceProvider serviceProvider )
        {
            return Converter.Value;
        }
    }
}
