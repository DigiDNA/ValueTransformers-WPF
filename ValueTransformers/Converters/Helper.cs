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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace ValueTransformers
{
    public static class Helper
    {
        public static Visibility ToVisibility( Func< bool > isVisible, object? parameter )
        {
            return isVisible() ? Visibility.Visible : parameter is string s && s.ToLower() == "collapsed" ? Visibility.Collapsed : Visibility.Hidden;
        }
    
        public static void CheckTargetType( Type target, Type expected )
        {
            if( target == null  )
            {
                throw new ArgumentNullException( nameof( target ) );
            }
        
            if( expected == null  )
            {
                throw new ArgumentNullException( nameof( expected ) );
            }
        
            if( target != typeof( object ) && target != expected && target.IsSubclassOf( expected ) == false )
            {
                throw new ArgumentException( "Invalid target type", nameof( target ) );
            }
        }
    
        public static bool IsZero( object? value )
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

        public static double ParseDouble( object? o )
        {
            if( o is string str )
            {
                return double.Parse( str, System.Globalization.CultureInfo.InvariantCulture );
            }

            return Convert.ToDouble( o );
        }
    }
}
