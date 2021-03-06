﻿using TaskWeb.Entitys;
using TaskWeb.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskWeb.Models;

namespace TaskWeb.Controllers
{
    public class AchievementController : BaseController
    {
        AchievementManager achievementManager = new AchievementManager();
        ResultManager resultManager = new ResultManager();

        public ActionResult List()
        {
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }


        /// <summary>
        /// 获取成就列表
        /// </summary>
        /// <returns></returns>
        public JsonResult DoGetList()
        {
            jsonResult.Data = achievementManager.getAchievementDtoList();
            return jsonResult;
        }

        /// <summary>
        /// 添加成就
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public JsonResult DoAdd(AchievementDto dto)
        {
            dto.creator = TaskWebSession.id;
            return achievementManager.AddAchievement(dto) ?
                resultManager.SuccessResult() : resultManager.FailureResult();
        }
    }
}
