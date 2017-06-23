# Calculator
C#计算器程序


计算器模式
num表示按数值
symbol表示按运算符号
=表示按等于号

模式区分以按下等于号为结束。
目前窗口值会作为被运算数值被存到对应的list中。

1.启动或者清零后第一次按数字，然后按等于
num -> =
2.只按一次数字
num -> symbol -> =
3.正常运算方式
num -> symbol -> num -> =
4.
num -> symbol -> num -> = -> = .....