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
    [ MarkupExtensionReturnType( typeof( IValueConverter ) ) ]
    [ ValueConversion( typeof( bool ), typeof( Visibility ) ) ]
    public class BoolToInvisibility: MarkupExtension, IValueConverter
    {
        public object Convert( object? value, Type targetType, object? parameter, System.Globalization.CultureInfo? culture )
        {
            Helper.CheckTargetType( targetType, typeof( Visibility ) );

            if( ( value is bool ) == false )
            {
                throw new ArgumentException( "Invalid value", nameof( value ) );
            }

            return Helper.ToVisibility( () => ( bool )value == false, parameter );
        }

        public object? ConvertBack( object? value, Type targetType, object? parameter, System.Globalization.CultureInfo? culture )
        {
            throw new NotSupportedException();
        }

        private static readonly Lazy< BoolToInvisibility > Converter = new Lazy< BoolToInvisibility >( () => new BoolToInvisibility() );

        public override object ProvideValue( IServiceProvider serviceProvider )
        {
            return Converter.Value;
        }
    }
}
