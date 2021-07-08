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
    public class IsNull
    {
        private readonly ValueTransformers.IsNull Converter = new ValueTransformers.IsNull();
        
        [ TestMethod ]
        public void TestNull()
        {
            Assert.IsTrue( ( bool )this.Converter.Convert( null, typeof( bool ), null, null ) );
        }

        [ TestMethod ]
        public void TestNotNull()
        {
            Assert.IsFalse( ( bool )this.Converter.Convert( "hello, world", typeof( bool ), null, null ) );
        }
    }
}
