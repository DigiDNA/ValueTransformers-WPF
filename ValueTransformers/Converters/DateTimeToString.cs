/*******************************************************************************
 * Copyright (c) 2019, DigiDNA
 * All rights reserved
 * 
 * Unauthorised copying of this copyrighted work, via any medium is strictly
 * prohibited.
 * Proprietary and confidential.
 ******************************************************************************/

using System;
using System.Globalization;
using System.Threading;
using System.Windows.Data;
using System.Windows.Markup;

namespace ValueTransformers
{
    [ MarkupExtensionReturnType( typeof( IValueConverter ) ) ]
    [ ValueConversion( typeof( object ), typeof( string ) ) ]
    public class DateTimeToString: MarkupExtension, IValueConverter
    {
        public enum DateFormatStyle
        {
            None,
            Short,
            Long
        }

        public enum TimeFormatStyle
        {
            None,
            Short,
            Long
        }

        public DateFormatStyle DateStyle
        {
            get;
            set;
        }

        public TimeFormatStyle TimeStyle
        {
            get;
            set;
        }

        public static string ToString( DateTime dt, DateFormatStyle dateStyle, TimeFormatStyle timeStyle )
        {
            string format       = "";
            CultureInfo culture = Thread.CurrentThread.CurrentCulture;

            switch( dateStyle )
            {
                case DateFormatStyle.Short: format += culture.DateTimeFormat.ShortDatePattern; break;
                case DateFormatStyle.Long:  format += culture.DateTimeFormat.LongDatePattern;  break;
                default:                    break;
            }

            if( format.Length > 0 && timeStyle != TimeFormatStyle.None )
            {
                format += " ";
            }

            switch( timeStyle )
            {
                case TimeFormatStyle.Short: format += culture.DateTimeFormat.ShortTimePattern; break;
                case TimeFormatStyle.Long:  format += culture.DateTimeFormat.LongTimePattern;  break;
                default:                    break;
            }

            if( format.Length == 0 )
            {
                return "";
            }

            return dt.ToString( format );
        }

        public static DateTime DateTimeFromUnixTimestamp( long ts, DateTimeKind kind = DateTimeKind.Utc )
        {
            DateTime dt = new DateTime( 1970, 1, 1, 0, 0, 0, 0, kind );

            return dt.AddSeconds( ts ).ToLocalTime();
        }

        public static string ToString( long ts, DateFormatStyle dateStyle, TimeFormatStyle timeStyle )
        {
            return ToString( DateTimeFromUnixTimestamp( ts ), dateStyle, timeStyle );
        }

        public DateTimeToString(): this( DateFormatStyle.Short, TimeFormatStyle.Short )
        {}

        public DateTimeToString( DateFormatStyle dateStyle, TimeFormatStyle timeStyle )
        {
            this.DateStyle = dateStyle;
            this.TimeStyle = timeStyle;
        }

        public string Convert( DateTime dt )
        {
            return ToString( dt, this.DateStyle, this.TimeStyle );
        }

        public string Convert( long ts )
        {
            return ToString( ts, this.DateStyle, this.TimeStyle );
        }

        public object Convert( object? value, Type targetType, object? parameter, System.Globalization.CultureInfo? culture )
        {
            DateFormatStyle dateStyle = this.DateStyle;
            TimeFormatStyle timeStyle = this.TimeStyle;

            if( targetType != typeof( string ) && targetType != typeof( object ) )
            {
                throw new ArgumentException( "Invalid target type", nameof( targetType ) );
            }

            if( parameter is string format )
            {
                string[] options = format.ToLower().Split( ':' );

                if( options.Length > 0 )
                {
                    switch( options[ 0 ] )
                    {
                        case "none":  dateStyle = DateFormatStyle.None;  timeStyle = TimeFormatStyle.None;  break;
                        case "short": dateStyle = DateFormatStyle.Short; timeStyle = TimeFormatStyle.Short; break;
                        case "long":  dateStyle = DateFormatStyle.Long;  timeStyle = TimeFormatStyle.Long;  break;
                        default:      break;
                    }
                }

                if( options.Length > 1 )
                {
                    switch( options[ 1 ] )
                    {
                        case "none":  timeStyle = TimeFormatStyle.None;  break;
                        case "short": timeStyle = TimeFormatStyle.Short; break;
                        case "long":  timeStyle = TimeFormatStyle.Long;  break;
                        default:      break;
                    }
                }
            }

            if( ( value is DateTime dt ) )
            {
                return ToString( dt, dateStyle, timeStyle );
            }

            if( ( value is long l ) )
            {
                return ToString( l, dateStyle, timeStyle );
            }

            /*
             * This is to support date properties in iMazing's StorageItemNode, that may sometimes
             * return a string instead of a DateTime.
             * Really poor design choice, but as I don't want to touch that...
             */
            if( value is string )
            {
                return value;
            }

            throw new ArgumentException( "Invalid value", nameof( value ) );
        }

        public object? ConvertBack( object? value, Type targetType, object? parameter, System.Globalization.CultureInfo? culture )
        {
            throw new NotSupportedException();
        }

        private static DateTimeToString? Converter
        {
            get;
            set;
        }

        public override object ProvideValue( IServiceProvider serviceProvider )
        {
            if( Converter == null )
            {
                Converter = new DateTimeToString();
            }

            return Converter;
        }
    }
}
