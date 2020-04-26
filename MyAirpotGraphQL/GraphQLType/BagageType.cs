using ECE.AA.MyAirport.EF;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAirpotGraphQL.GraphQLType
{
    public class BagageType: ObjectGraphType<Bagage>
    {
        public BagageType()
        {
            Field(x => x.ID_BAGAGE);
            Field(x => x.CLASSE);
            Field(x => x.CODE_IATA);
            Field(x => x.DATE_CREATION);
            Field(x => x.DESTINATION);
            Field(x => x.ESCALE);
            Field(x => x.PRIORITAIRE);
            Field(x => x.STA);
            Field(x => x.SSUR);
            Field(x => x.ID_VOL);

        }
    }
}
