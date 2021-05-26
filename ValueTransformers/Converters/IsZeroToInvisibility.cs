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
	public class IsZeroToInvisibility: MarkupExtension, IValueConverter
	{
		public object Convert( object value, Type targetType, object parameter, System.Globalization.CultureInfo culture )
        {
            if( targetType != typeof( Visibility ) )
            {
                throw new ArgumentException();
            }

            return Helper.ToVisibility( () => Helper.IsZero( value ) == false, parameter );
        }

        public object ConvertBack( object value, Type targetType, object parameter, System.Globalization.CultureInfo culture )
		{
			throw new NotSupportedException();
		}

		private static IsZeroToInvisibility? Converter
        {
            get;
            set;
        }

		public override object ProvideValue( IServiceProvider serviceProvider )
		{
			if( Converter == null )
			{
				Converter = new IsZeroToInvisibility();
			}

			return Converter;
		}
    }
}
