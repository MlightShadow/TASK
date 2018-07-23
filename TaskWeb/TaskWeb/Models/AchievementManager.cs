using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskWeb.Entitys;
using TaskWeb.Utils;

namespace TaskWeb.Models
{
    public class AchievementManager : BaseManager
    {
        public List<AchievementDto> getAchievementDtoList()
        {
            SQLExecuteParam param = new SQLExecuteParam();
            param.sql = @"SELECT
                        tb_achievement.id,
                        tb_achievement.title,
                        tb_achievement.content,
                        tb_achievement.`status`,
                        tb_achievement.is_deleted,
                        tb_achievement.creator,
                        tb_achievement.create_time,
                        tb_achievement.pass_time
                        FROM
                        tb_achievement order by id desc
                        ";
            return DBAgent.SQLExecuteReturnList<AchievementDto>(param);
        }

        public bool AddAchievement(AchievementDto dto)
        {
            SQLExecuteParam param = new SQLExecuteParam();
            param.obj = dto;
            param.sql = @"
                        INSERT INTO tb_achievement (
	                        title,
	                        content,
	                        `status`,
	                        is_deleted,
	                        creator,
	                        create_time
                        )
                        VALUES
	                        (
		                        @title,
		                        @content,
		                        1,
		                        0,
		                        @creator,
		                        now()
	                        )
                ";

            if (DBAgent.SQLExecuteReturnRows(param) == 1) {
                return true;
            }
            else {
                return false;
            }
        }

        public bool EditAchievement(AchievementDto dto)
        {
            return false;
        }

        public bool DeleteAchievement(AchievementDto dto)
        {
            return false;
        }
    }
}