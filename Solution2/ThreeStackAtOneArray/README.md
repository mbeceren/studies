Tek bir dizi içerisinde, 3 tane stack tutmaya yarayan program.
Çözüm;
	Bir dizi içerisinde 3 ayrı stack tutmak için başlangıçta stackler'in top değerleri yerleştirilir. 
		n ana dizinin uzunluğu olsun
		1.Stack'in başlangıç top değeri -1 olacak ve eleman eklendikçe top değeri 1 artırılacak.
		3.Stack'in başlangıç top değer n olacak ve eleman eklendikçe top değeri 1 azaltılacak.
		2.Stack'in başlangıç top değeri (n/3)'ün aşağı yuvarlanmış değeri olacak, eleman eklendikte top değeri 1 artırılacak.
	Bu formulasyona göre her bir stack için kendi pop ve push fonksiyonları implemente edilir. 
	2.Stack dizinin ortasında konumlandığı için duruma göre diğer stack'lerle arasında boş alan kalmayabileceğinden, 2.Stack duruma göre yeniden konumlandırılır. 
	2.Stack'in tekrar konumlandırma yaklaşımı, 1. ve 3.Stacklere uzaklığı eşit olacak şekildedir. 
	- 1.Stack'in top değeri 2.Stack'in head değerinden bir eksikse ve 1.Stack'in push fonksiyonu çağırılırsa
	veya
	- 3.Stack'in top değeri 2.Stack'in top değerinden bir fazlaysa ve 3.Stack'in push fonksiyonu çağırılırsa
	veya
	- 3.Stack'in top değeri 2.Stack'in top değerinden bir fazlaysa ve 2.Stack'in push fonksiyonu çağırılırsa
	2.Stack yenilen konumlandırılır.