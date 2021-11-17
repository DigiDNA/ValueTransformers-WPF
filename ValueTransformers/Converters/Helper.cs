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
    internal static class Helper
    {
        internal static Visibility ToVisibility( Func< bool > isVisible, object parameter )
        {
            if( isVisible == null )
            {
                throw new ArgumentNullException();
            }

            return isVisible() ? Visibility.Visible : parameter is string s && s.ToLower() == "collapsed" ? Visibility.Collapsed : Visibility.Hidden;
        }

        public static void CheckTargetType( Type target, Type expected )
        {
            if( target == null )
            {
                throw new ArgumentNullException( nameof( target ) );
            }

            if( expected == null )
            {
                throw new ArgumentNullException( nameof( expected ) );
            }

            if( target != typeof( object ) && target != expected && target.IsSubclassOf( expected ) == false )
            {
                throw new ArgumentException( "Invalid target type", nameof( target ) );
            }
        }

        internal static bool IsZero( object value )
        {
            if( value is char )
            {
                return ( char )value == 0;
            }

            if( value is sbyte )
            {
                return ( sbyte )value == 0;
            }

            if( value is byte )
            {
                return ( byte )value == 0;
            }

            if( value is short )
            {
                return ( short )value == 0;
            }

            if( value is ushort )
            {
                return ( ushort )value == 0;
            }

            if( value is int )
            {
                return ( int )value == 0;
            }

            if( value is uint )
            {
                return ( uint )value == 0;
            }

            if( value is long )
            {
                return ( long )value == 0;
            }

            if( value is ulong )
            {
                return ( ulong )value == 0;
            }

            if( value is float )
            {
                return ( float )value == 0.0f;
            }

            if( value is double )
            {
                return ( double )value == 0.0d;
            }

            if( value is decimal )
            {
                return ( decimal )value == 0;
            }

            throw new ArgumentException();
        }
    }
}
