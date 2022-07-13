# Big-O - Definição, Exemplos e Benchmark
Em poucas palavras, Big-O é uma classificação para a complexidade do algoritmo.

## **Big-O - Notações**
As notações Big-O são notações matemáticas que podem ser usadas para descrever a complexidade do algoritmo.

### O(1) (constante)
Não há crescimento do número de operações, pois não depende do volume de dados de entrada (n).

### O(log n) (logaritmo) 
O crescimento do número de operações é menor do que o do número de itens.

### O(n) (linear)
O crescimento no número de operações é diretamente proporcional ao crescimento do número de itens.

### O(n log n) (linearitmica ou quasilinear)
É o resultado das operações **(log n)** executada **n** vezes.

### O(n^2) (quadrático)
Ocorre quando os itens de dados são processados aos pares, muitas vezes com repetições dentro da outra.

### O(2^n) (exponencial)
A medida que n aumenta, o fator analisado (tempo ou espaço) aumenta exponencialmente.

### O(n!) (fatorial)
O número de instruções executadas cresce muito rapidamente para um pequeno número de dados.

![Screenshot](assets/big-o-complexity-chart.png)

## **Big-O - Notação Alternativa**

| Big-O         | Alternativa   |
| ------------- | ------------- |
| **O(1)**  		| **O(yeah)**		|
| **O(log n)** 	| **O(nice)**		|
| **O(n)** 		  | **O(ok)**			|
| **O(n log n)**| **O(uch)**  	|
| **O(n^2)** 		| **O(my)** 	 	|
| **O(2^n)**  	| **O(no)**	 		|
| **O(n!)**			| **O(mg!)**  	|
