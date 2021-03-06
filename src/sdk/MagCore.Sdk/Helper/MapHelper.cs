﻿using MagCore.Sdk.Common;
using MagCore.Sdk.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace MagCore.Sdk.Helper
{
    public static class MapHelper
    {
        public static Map GetMap(string map)
        {
            var code = ApiReq.CreateReq()
                        .WithMethod("api/map/" + map, "get")
                        .GetResult(out string json);
            if (code == System.Net.HttpStatusCode.OK)
            {
                var result = DynamicJson.Parse(json);
                Map m = new Map();
                m.Edge = (int)result.Edge;
                m.Shift = (int)result.Shift;
                m.Direction = (int)result.Direction;

                m.Rows = new List<Row>();
                int i = 0;
                foreach (string item in result.Rows)
                {
                    Row row = new Row(i, item.Length);
                    for (int j = 0; j < item.Length; j++)
                    {
                        row.Cells[j].Type = Int32.Parse(item[j].ToString());
                    }
                    m.Rows.Add(row);

                    i++;
                }

                return m;
            }
            else
                return null;
        }

        public static void Attack(string gameId, string playerId, int x, int y)
        {
            string parms = string.Format("{{\"Game\":\"{0}\", \"Player\":\"{1}\", \"X\":{2}, \"Y\":{3}}}",
                            gameId, playerId, x, y);
            var content = new StringContent(parms, Encoding.UTF8, "application/json");
            var code = ApiReq.CreateReq()
                        .WithMethod("api/cell", "put", content)
                        .GetResult(out string json);
        }
    }
}
