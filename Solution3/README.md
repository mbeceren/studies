İskambil kağıtları için genel data yapısıyla, 21(Blackjack) oyununun implementasyonu amaçlayan .NET Core konsol uygulaması. 
Çözüm;
	Blackjack.Tool altında İskambil kağıtları için oluşturulmuş genel data yapısı bulunmaktadır.
	Bu genel yapı kullanılarak Blackjack.Game altında 21(Blackjack) oyunu implemente edilmiştir.
	"Game" sınıfı 21 oyununu temsil eder. Oyunun kaç deste ile oynanacağının karar verilmesi ile oyun başlatılır. Her bir 21 oyununun iki oyuncusu olduğu varsayılmıştır. 
		Birinci oyuncu: Dealer(Dağıtıcı)
		İkinci oyuncu: Player(Oyuncu)
	
	"Round" sınıfı 21 oyunundaki her bir eli ifade etmektedir. Her round başladığında, oyunculara 2'şer kart dağıtılır. 
	"Hand" sınıfı, her bir Round'da Player'ların kartlarını, yani elini, ifade eder.