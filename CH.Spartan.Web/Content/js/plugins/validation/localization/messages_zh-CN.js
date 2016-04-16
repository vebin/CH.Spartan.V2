(function( factory ) {
	if ( typeof define === "function" && define.amd ) {
		define( ["jquery", "../jquery.validate"], factory );
	} else if (typeof module === "object" && module.exports) {
		module.exports = factory( require( "jquery" ) );
	} else {
		factory( jQuery );
	}
}(function( $ ) {

/*
 * Translated default messages for the jQuery validation plugin.
 * Locale: ZH (Chinese, 中文 (Zhōngwén), 汉语, 漢語)
 */
$.extend( $.validator.messages, {
	required: "这是必填字段",
	remote: "请修正此字段",
	email: "请输入有效的电子邮件地址",
	url: "请输入有效的网址",
	date: "请输入有效的日期",
	dateISO: "请输入有效的日期 (YYYY-MM-DD)",
	number: "请输入有效的数字",
	digits: "只能输入数字",
	creditcard: "请输入有效的信用卡号码",
	equalTo: "你的输入不相同",
	extension: "请输入有效的后缀",
	maxlength: $.validator.format( "最多可以输入 {0} 个字符" ),
	minlength: $.validator.format( "最少要输入 {0} 个字符" ),
	rangelength: $.validator.format( "请输入长度在 {0} 到 {1} 之间的字符串" ),
	range: $.validator.format( "请输入范围在 {0} 到 {1} 之间的数值" ),
	max: $.validator.format( "请输入不大于 {0} 的数值" ),
	min: $.validator.format("请输入不小于 {0} 的数值"),
	isLicensePlate: "请输入有效的车牌号码",
	isEmail: "请输入有效的电子邮件地址",
	isMoney: $.validator.format("请输入有效的金额 例如120.55"),
	isFloat: $.validator.format("只能包含数字、小数点等字符"),
	isInteger: $.validator.format("匹配整形"),
	isNumber: $.validator.format("匹配数值类型，包括整数和浮点数"),
	isDigits: $.validator.format("只能输入0-9数字"),
	isChinese: $.validator.format("只能包含中文字符。"),
	isEnglish: $.validator.format("只能包含英文字符。"),
	isEnglishAndNumber: $.validator.format("只能包含英文字符和数字。"),
	isMobile: $.validator.format("请正确填写您的手机号码。"),
	isPhone: $.validator.format("请正确填写您的电话号码。"),
	isTel: $.validator.format("请正确填写您的联系方式"),
	isQq: $.validator.format("匹配QQ"),
	isZipCode: $.validator.format("请正确填写您的邮政编码"),
	isPwd: $.validator.format("以字母开头，长度在6-12之间，只能包含字符、数字和下划线。"),
	isIdCardNo: $.validator.format("请输入正确的身份证号码。"),
	ip: $.validator.format("请填写正确的IP地址。"),
	isIntEqZero: $.validator.format("整数必须为0"),
	isIntGtZero: $.validator.format("整数必须大于0"),
	isIntGteZero: $.validator.format("整数必须大于或等于0"),
	isIntNEqZero: $.validator.format("整数必须不等于0"),
	isIntLtZero: $.validator.format("整数必须小于0"),
	isIntLteZero: $.validator.format("整数必须小于或等于0"),
	isFloatEqZero: $.validator.format("浮点数必须为0"),
	isFloatGtZero: $.validator.format("浮点数必须大于0"),
	isFloatGteZero: $.validator.format("浮点数必须大于或等于0"),
	isFloatNEqZero: $.validator.format("浮点数必须不等于0"),
	isFloatLtZero: $.validator.format("浮点数必须小于0"),
	isFloatLteZero: $.validator.format("浮点数必须小于或等于0"),
	stringCheck: $.validator.format("只能包含中文、英文、数字、下划线等字符"),
	isChineseChar: $.validator.format("匹配中文(包括汉字和字符)"),
	isRightfulString: $.validator.format("判断是否为合法字符(a-zA-Z0-9-_)"),
	isContainsSpecialChar: $.validator.format("含有中英文特殊字符")
} );

}));