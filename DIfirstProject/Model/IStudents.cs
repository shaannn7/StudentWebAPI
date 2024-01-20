namespace DIfirstProject.Model
{
    public interface IStudents
    {

                   // GET //
        public List<Students> GetStudents();
        public Students GetStudentById(int id);

                   // POST //
        public void AddStudent(Students student);
                   
                   // PUT  //
        public void UpdateStudent(int id , Students student);
            
                  // DELETE // 
        public void DeleteStudent(int id); 
    }


    public class StudentRepository:IStudents
    {
        List<Students> students = new List<Students>
        {
           new Students { Id = 1 , Name = "Thameem" , Age = 15 },
           new Students { Id = 2 , Name = "Shamil" , Age = 14 },
           new Students { Id = 3 , Name = "Shaann" , Age =16 }
        };

            //GET//
        public List<Students> GetStudents()
        {
            return students;
        }

        public Students GetStudentById(int id)
        {
            var STDbyID = students.FirstOrDefault(x => x.Id == id);
            return STDbyID;
        }

            //POST//

        public void AddStudent(Students student)
        {
            students.Add(student);
        }

            //PUT//
        public void UpdateStudent(int id, Students student)
        {
            var STDupdt = students.FirstOrDefault(students => students.Id == id);
            STDupdt.Name = student.Name;    
            STDupdt.Age = student.Age;
        }

            //DELETE//
        public void DeleteStudent(int id)
        {
            var DeleteStdnt = students.FirstOrDefault(s => s.Id == id);
            students.Remove(DeleteStdnt);
        }
    }
}
