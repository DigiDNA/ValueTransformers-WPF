/*******************************************************************************
 * Copyright (c) 2019, DigiDNA
 * All rights reserved
 * 
 * Unauthorised copying of this copyrighted work, via any medium is strictly
 * prohibited.
 * Proprietary and confidential.
 ******************************************************************************/

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [ TestClass ]
    public class IsZero
    {
        private readonly ValueTransformers.IsZero Converter = new ValueTransformers.IsZero();
        
        [ TestMethod ]
        public void TestZero()
        {
            Assert.IsTrue( ( bool )this.Converter.Convert( ( char    )0, typeof( bool ), null, null ) );
            Assert.IsTrue( ( bool )this.Converter.Convert( ( sbyte   )0, typeof( bool ), null, null ) );
            Assert.IsTrue( ( bool )this.Converter.Convert( ( byte    )0, typeof( bool ), null, null ) );
            Assert.IsTrue( ( bool )this.Converter.Convert( ( short   )0, typeof( bool ), null, null ) );
            Assert.IsTrue( ( bool )this.Converter.Convert( ( ushort  )0, typeof( bool ), null, null ) );
            Assert.IsTrue( ( bool )this.Converter.Convert( ( int     )0, typeof( bool ), null, null ) );
            Assert.IsTrue( ( bool )this.Converter.Convert( ( uint    )0, typeof( bool ), null, null ) );
            Assert.IsTrue( ( bool )this.Converter.Convert( ( long    )0, typeof( bool ), null, null ) );
            Assert.IsTrue( ( bool )this.Converter.Convert( ( ulong   )0, typeof( bool ), null, null ) );
            Assert.IsTrue( ( bool )this.Converter.Convert( ( float   )0, typeof( bool ), null, null ) );
            Assert.IsTrue( ( bool )this.Converter.Convert( ( double  )0, typeof( bool ), null, null ) );
            Assert.IsTrue( ( bool )this.Converter.Convert( ( decimal )0, typeof( bool ), null, null ) );
        }

        [ TestMethod ]
        public void TestNotZero()
        {
            Assert.IsFalse( ( bool )this.Converter.Convert( ( char    )42, typeof( bool ), null, null ) );
            Assert.IsFalse( ( bool )this.Converter.Convert( ( sbyte   )42, typeof( bool ), null, null ) );
            Assert.IsFalse( ( bool )this.Converter.Convert( ( byte    )42, typeof( bool ), null, null ) );
            Assert.IsFalse( ( bool )this.Converter.Convert( ( short   )42, typeof( bool ), null, null ) );
            Assert.IsFalse( ( bool )this.Converter.Convert( ( ushort  )42, typeof( bool ), null, null ) );
            Assert.IsFalse( ( bool )this.Converter.Convert( ( int     )42, typeof( bool ), null, null ) );
            Assert.IsFalse( ( bool )this.Converter.Convert( ( uint    )42, typeof( bool ), null, null ) );
            Assert.IsFalse( ( bool )this.Converter.Convert( ( long    )42, typeof( bool ), null, null ) );
            Assert.IsFalse( ( bool )this.Converter.Convert( ( ulong   )42, typeof( bool ), null, null ) );
            Assert.IsFalse( ( bool )this.Converter.Convert( ( float   )42, typeof( bool ), null, null ) );
            Assert.IsFalse( ( bool )this.Converter.Convert( ( double  )42, typeof( bool ), null, null ) );
            Assert.IsFalse( ( bool )this.Converter.Convert( ( decimal )42, typeof( bool ), null, null ) );

            Assert.IsFalse( ( bool )this.Converter.Convert( ( sbyte   )-42, typeof( bool ), null, null ) );
            Assert.IsFalse( ( bool )this.Converter.Convert( ( short   )-42, typeof( bool ), null, null ) );
            Assert.IsFalse( ( bool )this.Converter.Convert( ( int     )-42, typeof( bool ), null, null ) );
            Assert.IsFalse( ( bool )this.Converter.Convert( ( long    )-42, typeof( bool ), null, null ) );
            Assert.IsFalse( ( bool )this.Converter.Convert( ( float   )-42, typeof( bool ), null, null ) );
            Assert.IsFalse( ( bool )this.Converter.Convert( ( double  )-42, typeof( bool ), null, null ) );
            Assert.IsFalse( ( bool )this.Converter.Convert( ( decimal )-42, typeof( bool ), null, null ) );
        }

        [ TestMethod ]
        public void TestNull()
        {
            Assert.ThrowsException< ArgumentException >( () => this.Converter.Convert( null, typeof( bool ), null, null ) );
        }

        [ TestMethod ]
        public void TestBadType()
        {
            Assert.ThrowsException< ArgumentException >( () => this.Converter.Convert( "hello, world", typeof( bool ), null, null ) );
        }
    }
}
