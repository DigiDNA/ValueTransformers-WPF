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
    public class StringIsNotEmpty
    {
        private readonly ValueTransformers.StringIsNotEmpty Converter = new ValueTransformers.StringIsNotEmpty();
        
        [ TestMethod ]
        public void TestNull()
        {
            Assert.IsFalse( ( bool )this.Converter.Convert( null, typeof( bool ), null, null ) );
        }

        [ TestMethod ]
        public void TestEmptyString()
        {
            Assert.IsFalse( ( bool )this.Converter.Convert( "", typeof( bool ), null, null ) );
        }

        [ TestMethod ]
        public void TestString()
        {
            Assert.IsTrue( ( bool )this.Converter.Convert( "hello, world", typeof( bool ), null, null ) );
        }

        [ TestMethod ]
        public void TestNonString()
        {
            Assert.IsFalse( ( bool )this.Converter.Convert( 42, typeof( bool ), null, null ) );
        }
    }
}
