using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace nashtech_form.Mvc.Models
{
    public class Service
    {
        private readonly string _dataFile = @"Data\data.xml";
        private readonly XmlSerializer _serializer = new XmlSerializer(typeof(HashSet<Member>));
        public HashSet<Member> Members { get; set; }

        public Service()
        {
            if (!File.Exists(_dataFile))
            {
                Members = new HashSet<Member>() {
                    new Member{Id = 1, firstName = "nguyen" , lastName="chinh", Gender="Male", DOB= new DateTime(2000,5,12), phoneNumber= 0925302500, birthPlace="Ha Noi", Age = 21, isGraduated = true},
                    new Member{Id = 2, firstName = "nguyen" , lastName="chien", Gender="Male", DOB= new DateTime(1964,04,09), phoneNumber= 0934571699, birthPlace="Ha Noi", Age = 54, isGraduated = true},
                    
                };
            }
            else
            {
                using var stream = File.OpenRead(_dataFile);
                Members = _serializer.Deserialize(stream) as HashSet<Member>;
            }
        }

        public Member[] Get() => Members.ToArray();

        public Member Get(int id) => Members.FirstOrDefault(b => b.Id == id);        

        public bool Add(Member member) => Members.Add(member);

        public Member Create()
        {
            var max = Members.Max(b => b.Id);
            var b = new Member()
            {
                Id = max + 1,
            };
            return b;
        }

        public bool Update(Member member)
        {
            var b = Get(member.Id);
            return b != null && Members.Remove(b) && Members.Add(member);
        }

        public bool Delete(int id)
        {
            var b = Get(id);
            return b != null && Members.Remove(b);
        }

        public void SaveChanges()
        {
            using var stream = File.Create(_dataFile);
            _serializer.Serialize(stream, Members);
        }
    }
}