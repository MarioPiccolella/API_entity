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
    public class Washers_SkillsController : ControllerBase
    {

        //REMOVING BY SKILL AND WASHER ID
        [HttpDelete]
        public void Delete(int skill_id,int washer_id)
        {
            //CHECKING IF WASHER AND SKILL EXIST
            API_entity.DataModels.Context mycontext = new DataModels.Context();
            
            //CHECKINF THAT WASHER AND SKILL HAVE TO EXIST
            if(mycontext.washers.SingleOrDefault(x => x.pkid == washer_id) != null && mycontext.skills.SingleOrDefault(x => x.pkid == skill_id) != null)
            {
                //REMOVE IF AVAILABLE IN JUNCTION TABLE

                washer_skill remove_single = mycontext.washers_skills.Where(x=>x.skill_id == skill_id && x.washer_id == washer_id).FirstOrDefault();
                if (remove_single != null)
                {
                    mycontext.washers_skills.Remove(remove_single);
                    mycontext.SaveChanges();
                }
                else
                {
                    throw new System.Web.Http.HttpResponseException(HttpStatusCode.NotFound);
                }
            }
            else
            {
                throw new System.Web.Http.HttpResponseException(HttpStatusCode.Forbidden);
            }
        }


        //BIND SKILL TO WASHER
        [HttpPost]
        public void Post(int skill_id,int washer_id)
        {
            API_entity.DataModels.Context mycontext = new DataModels.Context();

            //CHECKINF THAT WASHER AND SKILL HAVE TO EXIST
            if (mycontext.washers.SingleOrDefault(x => x.pkid == washer_id) != null && mycontext.skills.SingleOrDefault(x => x.pkid == skill_id) != null)
            {
                //INSERT NEW LINK
                washer_skill insert_single = new washer_skill();
                insert_single.skill_id = skill_id;
                insert_single.washer_id = washer_id;
                mycontext.washers_skills.Add(insert_single);
                mycontext.SaveChanges();
            }
            else
            {
                throw new System.Web.Http.HttpResponseException(HttpStatusCode.Forbidden);
            }


        }


    }
}
