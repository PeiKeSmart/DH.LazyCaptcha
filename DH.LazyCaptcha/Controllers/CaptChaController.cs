﻿using DH.RateLimter;

using Microsoft.AspNetCore.Mvc;

namespace DH.LazyCaptcha.Controllers;

/// <summary>
/// 验证码控制器
/// </summary>
[ApiExplorerSettings(IgnoreApi = true)]
public partial class CaptChaController : Controller
{
    private readonly ICaptcha _captcha;

    public CaptChaController(ICaptcha captcha)
    {
        _captcha = captcha;
    }

    /// <summary>
    /// 验证码，适用于跨平台。
    /// </summary>
    /// <returns></returns>
    [RateValve(Policy = Policy.Ip, Limit = 30, Duration = 60)]
    public IActionResult GetCheckCode()
    {
        var info = _captcha.Generate();
        var stream = new MemoryStream(info.Bytes);
        return File(stream, "image/gif");
    }
}