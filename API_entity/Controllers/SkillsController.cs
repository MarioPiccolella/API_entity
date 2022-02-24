using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_entity.Models;
using System.Net;

namespace API_entity.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {

        [HttpGet("{id}")]
        public skill Get(int id)
        {
            API_entity.DataModels.Context mycontext = new DataModels.Context();
            skill skill_search = mycontext.skills.SingleOrDefault(x => x.pkid == id);

            if (skill_search == null)
            {
                //WITH MESSAGE
                throw new System.Web.Http.HttpResponseException(HttpStatusCode.NotFound);
            }
            else
            {
                return skill_search;
            }
        }


        [HttpPost]
        public void Post(string skill_name)
        {
            //INSERT NEW SKILL ( JUST NAME NEEDED ) 
            API_entity.DataModels.Context mycontext = new DataModels.Context();
            skill new_skill = new skill();
            new_skill.name = skill_name;
            mycontext.skills.Add(new_skill);
            mycontext.SaveChanges();
        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                //DELETE SINGLE SKILL IF NOT ASSIGNED TO ANYONE
                API_entity.DataModels.Context mycontext = new DataModels.Context();
                skill skill_search = mycontext.skills.SingleOrDefault(x => x.pkid == id);

                //EXTRACTING FROM JUNCTION IF THERE IS OCCURANCE IN JUNCTION TABLE IF THERE IS NOT CAN BE DELETED
                if(mycontext.washers_skills.SingleOrDefault(x => x.skill_id == id) == null)
                {
                    //CAN DELETE
                    mycontext.skills.Remove(skill_search);
                    mycontext.SaveChanges();
                }
                else
                {
                    throw new System.Web.Http.HttpResponseException(HttpStatusCode.Conflict);
                }
               
            }
            catch
            {
                throw new System.Web.Http.HttpResponseException(HttpStatusCode.NotFound);
            }
        }


        [HttpPut]
        public void Put(skill new_skill)
        {
            try
            {
                //COMPLETE UPDATE NOT PARTIAL(ID UNCHANGED)
                API_entity.DataModels.Context mycontext = new DataModels.Context();
                skill old_skill = mycontext.skills.FirstOrDefault(x => x.pkid == new_skill.pkid);
                mycontext.Entry(old_skill).CurrentValues.SetValues(new_skill);
                mycontext.SaveChanges();
            }
            catch
            {
                throw new System.Web.Http.HttpResponseException(HttpStatusCode.InternalServerError);
            }

        }


    }
}
