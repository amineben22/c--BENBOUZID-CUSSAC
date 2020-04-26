using ECE.AA.MyAirport.EF;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAirpotGraphQL.GraphQLType
{
    public class AirportQuery : ObjectGraphType
    {
        public AirportQuery(AirportContext db)
        {
            Field<ListGraphType<BagageType>>(
                "bagages",
                resolve: context => db.Bagages.ToList());

            //Field<ListGraphType<BagageType>>(
                //"bagages",
                //resolve: context => db.Bagages.First(b => b.ID_BAGAGE == context.));
        }
    }
}
