# Support Vector Machine (Destek Vektör Makinesi)

Support Vector Machine (SVM) algoritması, ilk olarak 1963 yılında Vapnik tarafından bir lineer sınıflandırıcı oluşturmak için önerilmiştir. SVM, bir sınıflandırıcı oluşturmak için güçlü bir yöntemdir. Temel amacı, bir veya daha fazla özellik vektöründen gelen etiketleri tahmin etmek için iki sınıf arasında bir karar sınırı oluşturmaktır. Bu karar sınırı, hiper düzlem olarak bilinir ve her bir sınıfa ait en yakın veri noktalarından mümkün olduğunca uzakta konumlandırılır. Bu en yakın noktalar, destek vektörleri olarak adlandırılır.

Optimal hiper düzlem, aşağıdaki denklemleri sağlayan $w$ ve $b$ değerlerini bulmak için eğitilir:

$$
\begin{align*}
w^Tx_i + b &\geq +1 \quad \text{if } y_i = 1 \\
w^Tx_i + b &\leq -1 \quad \text{if } y_i = -1
\end{align*}
$$

Bir SVM modelini eğitmenin amacı, hiper düzlemi verileri ayırmak ve margin'i maksimize edecek $w$ ve $b$ değerlerini bulmaktır.

## Soft Margin Sınıflandırması

Gerçek dünya problemlerinde, verileri kesin olarak bölen bir çizgi elde etmek pek olası değildir ve eğrisel bir karar sınırımız olabilir. Verileri tam olarak bölen bir hiper düzlemimiz olabilir, ancak verilerde gürültü varsa bu istenmeyebilir. Düzgün bir sınırın, aykırı verilerin etrafında dönerek veya döngülere girerek bazı veri noktalarını görmezden gelmesi daha iyidir. Bu farklı bir şekilde ele alınır; burada "slack variables" terimi devreye girer. Büyük slack değişkenlerine sahip olabiliriz ve bu, verileri herhangi bir çizgiyle ayırmaya izin verir, bu nedenle böyle senaryolarda büyük slack'leri cezalandıran Lagrange değişkeni devreye girer.

## Kernel Fonksiyonu

Kernel fonksiyonunun fikri, olası yüksek boyutlu özellik uzayı yerine işlemlerin giriş uzayında gerçekleştirilmesini sağlamaktır. Çekirdek fonksiyonu, SVM ve performansı için kritik bir rol oynar. Farklı çekirdek fonksiyonları bulunmaktadır: Polinom, Gauss Radial Basis Temel Fonksiyon, Exponential Radial Basis Fonksiyon, Multi-Layer Perceptron gibi.

## Sınıflandırma İçin SVM

SVM, veri sınıflandırması için kullanışlı bir tekniktir. Bilinen etiketler, sistemin doğru şekilde çalışıp çalışmadığını belirtmede yardımcı olur. SVM sınıflandırmasındaki bir adım, bilinen sınıflarla yakından ilişkili olan özelliklerin tanımlanmasını içerir.

## SVM Uygulaması

Program, veri setini okur ve işler. Veri seti eğitim ve test kümelerine ayrılır. Eğitim örnekleri ve etiketler, eğitim örneğini belirlemek için kullanılmak üzere karıştırılır. Eğitim örnekleri ve etiketler, eğitim örneğini belirlemek için kullanılmak üzere karıştırılır. SVM modeli eğitilir ve test ve eğitim kümeleri için tahminler yapılır. Her döngüde, test ve eğitim kümeleri için doğruluklar yazdırılır. Belirli bir hedef doğruluğa ulaşılana kadar (örneğin %80), bu adımlar tekrarlanır. Hedef doğruluğa ulaşıldığında program hedefe ulaşıldığını bildirir ve çalışmayı sonlandırır.

## Sonuç

Modelin eğitim seti doğruluk değeri %36,34, test seti doğruluk değeri ise %40,35’tir. Buna bakılarak modelin beklenenden düşük bir performans sergilediği görülmektedir. Model, eğitim setinde de düşük doğruluk oranlarına sahiptir.

**Uygulamanın Github Linki:** [https://github.com/ramazang0kmen/SVMExample](https://github.com/ramazang0kmen/SVMExample)

## Kaynakça

- Huang, S., Cai, N., Pacheco, P. P., Narrandes, S., Wang, Y., & Xu, W. (2018). Applications of support vector machine (SVM) learning in cancer genomics. *Cancer genomics & proteomics*, 15(1), 41-51.
- Jakkula, V. (2006). Tutorial on support vector machine (svm). *School of EECS, Washington State University*, 37(2.5), 3.

[![GitHub stars](https://img.shields.io/github/stars/ramazang0kmen/SVMExample?style=social)](https://github.com/ramazang0kmen/SVMExample/stargazers)
[![GitHub forks](https://img.shields.io/github/forks/ramazang0kmen/SVMExample?style=social)](https://github.com/ramazang0kmen/SVMExample/network)
