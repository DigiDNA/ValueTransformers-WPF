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
    [ ValueConversion( typeof( object ), typeof( Visibility ) ) ]
    public class NullToVisibility: MarkupExtension, IValueConverter
    {
        public object Convert( object? value, Type targetType, object? parameter, System.Globalization.CultureInfo? culture )
        {
            Helper.CheckTargetType( targetType, typeof( Visibility ) );

            return Helper.ToVisibility( () => value == null, parameter );
        }

        public object? ConvertBack( object? value, Type targetType, object? parameter, System.Globalization.CultureInfo? culture )
        {
            throw new NotSupportedException();
        }

        private static readonly Lazy< NullToVisibility > Converter = new Lazy< NullToVisibility >( () => new NullToVisibility() );

        public override object ProvideValue( IServiceProvider serviceProvider )
        {
            return Converter.Value;
        }
    }
}
