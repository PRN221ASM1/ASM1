using EStore.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStore.Core.repository
{
    public interface IMemberRepository
    {
        Member FindById(int id);
        IList<Member> FindAll();
        int Add(Member member);
        int Update(Member member);
        int Delete(int id);

    }
}
