using ECE.AA.MyAirport.EF;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAirpotGraphQL.GraphQLType
{
    public class VolType: ObjectGraphType<Vol>
    {
        public VolType()
        {
            Field(x => x.ID_VOL);
            Field(x => x.CIE);
            Field(x => x.DES);
            Field(x => x.DHC);
            Field(x => x.IMM);
            Field(x => x.LIG);
            Field(x => x.PAX);
            Field(x => x.PKG);
        }
    }
}
