using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace WebApi.Models
{
    public abstract class BaseModel<Entity, Model> where Entity : BaseEntity where Model: class
    {


        

        public int Id { set; get; }
        public abstract Model GetModel(Entity entity);

        public abstract Entity GetEntity();
    }
}