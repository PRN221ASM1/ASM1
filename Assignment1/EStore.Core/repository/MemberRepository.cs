using EStore.Core.connection;
using EStore.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStore.Core.repository
{
    public class MemberRepository : IMemberRepository
    {
        private readonly EStoreContext _context;
        public MemberRepository(EStoreContext context)
        {
            _context = context;
        }
        public int Add(Member member)
        {
            _context.Members.Add(member);
            int result = _context.SaveChanges();
            return result;
        }

        public int Delete(int id)
        {
            Member member = _context.Members.FirstOrDefault(m=>m.MemberId == id);
            if (member != null)
            {
                int result = _context.SaveChanges();
                return result;
            }
            return 0;
        }

        public Member FindById(int id)
        {
            Member member = _context.Members.FirstOrDefault(m => m.MemberId == id);
            return member;
        }

        public IList<Member> FindAll()
        {
            List<Member> members = _context.Members.ToList();
            return members;
        }

        public int Update(Member member)
        {
            _context.Members.Update(member);
            int result = (_context.SaveChanges());
            return result;
        }
    }
}
