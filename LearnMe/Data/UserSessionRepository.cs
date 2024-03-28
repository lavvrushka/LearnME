﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearnMe.Models;


namespace LearnMe.Data
{
    public class UserSessionRepository
    {
        private readonly DbContext _dbContext;

        public UserSessionRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddSession(UserSession session)
        {
            _dbContext.Sessions.Add(session);
            _dbContext.SaveChanges();
        }

        public void UpdateSession(UserSession session)
        {
            session.Expiration = session.Expiration.AddDays(30);
            _dbContext.SaveChanges();
        }

        public UserSession GetSessionByToken(string token)
        {
            return _dbContext.Sessions.SingleOrDefault(s => s.Token == token);
        }
        public UserSession GetSessionByUserId(int UserId)
        {
            return _dbContext.Sessions.SingleOrDefault(s => s.UserId == UserId);
        }

        public void RemoveSessionByToken(string token)
        {
            _dbContext.Sessions.Remove(GetSessionByToken(token));
            _dbContext.SaveChanges();
        }
    }
}
