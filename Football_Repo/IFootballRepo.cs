using NguyenPhuongNam_SE173557;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_Repo
{
    public interface IFootballRepo
    {
        public ArrayList GetAll();

        public Football GetById(int id);

        public bool AddNewPlayer(Football football);

        public bool UpdatePlayerProfile(Football football);

        public bool DeletePlayerProfile(int playerId);

    }
}
