statements  : statement* --陈述

statement   : expr* --陈述

expr        : arith-expr*  --表达式

arith-expr  : term ((PLUS | MINUS) term)* --算术表达式

term        : factor (MUL | DIV) factor)*

factor      : (PLUS | MINUS) factor
            : power

## 说明

*   0次或多次
?   0次或一次
+   1次或多次