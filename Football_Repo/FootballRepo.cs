using Football_DAO;
using NguyenPhuongNam_SE173557;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_Repo
{
    public class FootballRepo : IFootballRepo
    {
        private FootballDAO _footballDAO; 

        public FootballRepo()
        {
            _footballDAO = new FootballDAO();
        }

        public bool AddNewPlayer(Football football) => _footballDAO.AddNewPlayer(football);

        public bool DeletePlayerProfile(int playerId) => _footballDAO.DeletePlayerProfile(playerId);

        public ArrayList GetAll() => _footballDAO.GetAll();

        public Football GetById(int id) => _footballDAO.GetById(id);

        public bool UpdatePlayerProfile(Football football) => _footballDAO.UpdatePlayerProfile(football);
    }
}
