/*******************************************************************************
 * Copyright (c) 2019, DigiDNA
 * All rights reserved
 * 
 * Unauthorised copying of this copyrighted work, via any medium is strictly
 * prohibited.
 * Proprietary and confidential.
 ******************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace ValueTransformers
{
    internal static class Helper
    {
        internal static Visibility ToVisibility( Func< bool > isVisible, object? parameter )
        {
            return isVisible() ? Visibility.Visible : parameter is string s && s.ToLower() == "collapsed" ? Visibility.Collapsed : Visibility.Hidden;
        }

        internal static bool IsZero( object? value )
        {
            {
                if( value is char n )
                {
                    return n == 0;
                }
            }

            {
                if( value is sbyte n )
                {
                    return n == 0;
                }
            }

            {
                if( value is byte n )
                {
                    return n == 0;
                }
            }

            {
                if( value is short n )
                {
                    return n == 0;
                }
            }

            {
                if( value is ushort n )
                {
                    return n == 0;
                }
            }

            {
                if( value is int n )
                {
                    return n == 0;
                }
            }

            {
                if( value is uint n )
                {
                    return n == 0;
                }
            }

            {
                if( value is long n )
                {
                    return n == 0;
                }
            }

            {
                if( value is ulong n )
                {
                    return n == 0;
                }
            }

            {
                if( value is float n )
                {
                    return n == 0.0f;
                }
            }

            {
                if( value is double n )
                {
                    return n == 0.0d;
                }
            }

            {
                if( value is decimal n )
                {
                    return n == 0;
                }
            }

            throw new ArgumentException( "Unsupported type", nameof( value ) );
        }
    }
}
