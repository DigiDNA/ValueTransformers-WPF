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

namespace ValueTransformers_Test
{
    [ TestClass ]
    public class NegateBoolean
    {
        private readonly ValueTransformers.NegateBoolean Converter = new ValueTransformers.NegateBoolean();
        
        [ TestMethod ]
        public void TestTrue()
        {
            Assert.IsFalse( ( bool )this.Converter.Convert( true, typeof( bool ), null, null ) );
        }

        [ TestMethod ]
        public void TestFalse()
        {
            Assert.IsTrue( ( bool )this.Converter.Convert( false, typeof( bool ), null, null ) );
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
