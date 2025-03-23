using DH.LazyCaptcha.Generator.Image.Option;

namespace DH.LazyCaptcha;

public class CaptchaOptions
{
    private const Int32 DEFAULT_CODE_LENGTH = 4;
    private CaptchaType _captchaType = CaptchaType.DEFAULT;

    /// <summary>
    /// 验证码类型
    /// </summary>
    public CaptchaType CaptchaType
    {
        get { return _captchaType; }
        set
        {
            if (value.IsArithmetic())
            {
                if (CodeLength == DEFAULT_CODE_LENGTH)
                {
                    CodeLength = 2;
                }
            }

            if (value.ContainsChinese())
            {
                ImageOption.FontFamily = DefaultFontFamilys.Instance.Kaiti;
            }

            _captchaType = value;
        }
    }

    /// <summary>
    /// 验证码长度 当CaptchaType为ARITHMETIC, ARITHMETIC_ZH时， 长度代表乘数个数
    /// </summary>
    public Int32 CodeLength { get; set; } = DEFAULT_CODE_LENGTH;

    /// <summary>
    /// 过期时长
    /// </summary>
    public Int32 ExpirySeconds { get; set; } = 60;

    /// <summary>
    /// code比较是否忽略大小写
    /// </summary>
    public Boolean IgnoreCase { get; set; } = true;

    /// <summary>
    /// 存储键前缀
    /// </summary>
    public String StoreageKeyPrefix { get; set; }

    /// <summary>
    /// 存储类型
    /// </summary>
    public virtual StoreType StoreType { get; set; } = StoreType.Session;

    /// <summary>
    /// 图片选项
    /// </summary>
    public CaptchaImageGeneratorOption ImageOption { get; set; } = new CaptchaImageGeneratorOption();
}
