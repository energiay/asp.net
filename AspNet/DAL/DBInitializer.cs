using AspNet.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace AspNet.DAL
{
    public class DBInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
               
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));



            ApplicationUser user = new ApplicationUser()
            {
                UserName = "Admin",
                Id = "Admin"
            };
            IdentityRole role = new IdentityRole("admin");

            userManager.Create(user, "Admin");//(user,password)
            roleManager.Create(role);
            userManager.AddToRole(user.Id, role.Name);




            ApplicationUser user1 = new ApplicationUser()
            {
                UserName = "tl",
                Id = "tl"
            };
            IdentityRole role1 = new IdentityRole("user");
                              
            userManager.Create(user1, "tl");//(user,password)
            roleManager.Create(role);
            userManager.AddToRole(user1.Id, role1.Name);
                



            List<Message> messages = new List<Message>();
            for (int i = 0; i < 10; i++)
            {
                Message message = new Message()
                {
                    PublishDate = DateTime.Now,
                    // Visits = 0,
                    Title = "Заголовок новости " + i,
                    Text = GenerateSeedText(i),
                    // User = user
                };

                context.Messages.Add(message);

                if (i > 4 && i < 12)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        Reply reply = new Reply()
                        {
                            Message = message,
                            Text = GenerateSeedTextReply(0, j),
                            PublishDate = DateTime.Now,
                            //User = user
                        };

                        context.Replies.Add(reply);
                    }
                }
            }

            context.SaveChanges();
        }

        string GenerateSeedText(int i)
        {
            StringBuilder sb = new StringBuilder();
            // sb.Append("Message " + i+"\n");
            for (int j = 0; j < 20; j++)
            {
                for (int k = 0; k < 5; k++)
                {
                    sb.Append("текст новости ");
                    sb.Append(i);
                    sb.Append(" ");
                }
                sb.Append("\n");
            }
            return sb.ToString();
        }

        string GenerateSeedTextReply(int iNews, int iComment)
        {
            StringBuilder sb = new StringBuilder();
            // sb.Append("Message " + i+"\n");
            for (int j = 0; j < 10; j++)
            {
                for (int k = 0; k < 2; k++)
                {
                    sb.Append("текст комментария ");
                    sb.Append(iComment);
                    sb.Append(" ");
                }
                sb.Append("\n");
            }
            return sb.ToString();
        }
    }
}