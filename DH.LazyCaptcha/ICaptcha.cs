﻿namespace DH.LazyCaptcha;

public interface ICaptcha
{
    /// <summary>
    /// 使用session及固定Key
    /// </summary>
    /// <returns></returns>
    CaptchaData Generate();

    /// <summary>
    /// 使用session及固定Key
    /// </summary>
    /// <returns></returns>
    CaptchaData GenerateSId(String SId);

    /// <summary>
    /// 生成验证码
    /// </summary>
    /// <param name="captchaId">验证码id</param>
    /// <param name="expirySeconds">缓存时间，未设定则使用配置时间</param>
    /// <returns></returns>
    CaptchaData Generate(String captchaId, Int32? expirySeconds = null);

    /// <summary>
    /// 校验
    /// </summary>
    /// <param name="captchaId">验证码id</param>
    /// <param name="code">用户输入的验证码</param>
    /// <param name="removeIfSuccess">校验成功时是否移除缓存(用于多次验证)</param>
    /// <returns></returns>
    Boolean Validate(String captchaId, String code, Boolean removeIfSuccess = true);
}
