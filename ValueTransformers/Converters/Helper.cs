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

namespace ValueTransformers
{
    internal static class Helper
    {
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
