using System;
using System.IO;

namespace DosyaVeKlasorIslemleri
{
    class Program
    {
        static void Main(string[] args)
        {
        BASADON:
            Console.Clear();
            Console.WriteLine("1-Yeni Öğrenci Kaydı");
            Console.WriteLine("2-Öğrenci Bilgilerini Güncelle");
            Console.WriteLine("3-Öğrenci Kaydı Silme");
            Console.WriteLine("4-Öğrenci Sınıf Değişikliği");
            Console.WriteLine("5-Çıkış");

            Console.WriteLine("Seçiminizi yapınız [1,2,3,4,5]");
            string secim = Convert.ToString(Console.ReadKey().KeyChar);

            string ogrno, sinif, sinif_klasor_yolu, ogrenci_klasor_yolu;

            switch (secim)
            {
                case "1":
                    Console.Clear();
                    Console.Write("Öğrenci numarsını giriniz:");
                    ogrno = Console.ReadLine();
                    Console.Write("Kayıt olunacak sınıf giriniz:");
                    sinif = Console.ReadLine();
                    sinif_klasor_yolu = @"C:\Okul\" + sinif;
                    ogrenci_klasor_yolu = @"C:\Okul\" + sinif + "\\" + ogrno;
                    if (System.IO.Directory.Exists(sinif_klasor_yolu) == true && System.IO.Directory.Exists(ogrenci_klasor_yolu) == false)
                    {
                        System.IO.Directory.CreateDirectory(ogrenci_klasor_yolu);
                        string dosya_adi = ogrno + ".txt";
                        string hedef_dosya_yolu = System.IO.Path.Combine(ogrenci_klasor_yolu, dosya_adi);
                        System.IO.File.Create(hedef_dosya_yolu).Close();
                        Console.WriteLine("{0} Numralı öğrenci için klasör ve dosya oluşturulmuştur.", ogrno);

                        string ad, soyad, cinsiyet, telno, adres;
                        Console.Write("Adı :");
                        ad = Console.ReadLine();
                        Console.Write("Soyadı :");
                        soyad = Console.ReadLine();
                        Console.Write("Cinsiyet :");
                        cinsiyet = Console.ReadLine();
                        Console.Write("Telefon no :");
                        telno = Console.ReadLine();
                        Console.Write("Adres :");
                        adres = Console.ReadLine();

                        string[] ogrbilgi =
                        {
                            "Öğrenci numarası :"+ogrno,
                            "Adı :" + ad,
                            "Soyadı :" + soyad,
                            "Cinsiyet :" + cinsiyet,
                            "Telefon no :" + telno,
                            "Adres :" + adres
                        };
                        System.IO.File.WriteAllLines(@"C:\Okul\" + sinif + "\\" + ogrno + "\\" + ogrno + ".txt", ogrbilgi);
                        Console.Write("Öğrenci bilgileri başarı ile kaydedilmiştir.");
                        Console.ReadKey();
                        goto BASADON;
                    }
                    if (System.IO.Directory.Exists(sinif_klasor_yolu) == false)
                    {
                        Console.Clear();
                        Console.Write("Okulda {0} isminde sınıf yoktur", sinif);
                        goto BASADON;
                    }
                    if (System.IO.Directory.Exists(ogrenci_klasor_yolu) == true)
                    {
                        Console.Clear();
                        Console.Write("Okulda {0} sınıfında {1} numaralı ogrenci zaten mevcutdur!", sinif, ogrno);
                        goto BASADON;
                    }
                    Console.ReadKey();
                    break;
                case "2":
                    Console.Clear();
                    Console.Write("Öğrencinin numarasını girin:");
                    ogrno = Console.ReadLine();
                    System.IO.DirectoryInfo klasorbilgisi = new System.IO.DirectoryInfo("C:\\Okul");
                    System.IO.FileInfo[] dosyalar = klasorbilgisi.GetFiles(ogrno + ".txt", System.IO.SearchOption.AllDirectories);
                    int adet = dosyalar.Length;
                    if (adet > 0)
                    {
                        string ogrenci_dosya_yolu = dosyalar[0].DirectoryName;
                        string ogrenci_dosya_adi = ogrno + ".txt";
                        string ogrenci_hedef_yolu = System.IO.Path.Combine(ogrenci_dosya_yolu, ogrenci_dosya_adi);
                        string[] ogrenci_bilgileri = System.IO.File.ReadAllLines(ogrenci_hedef_yolu);
                    GUNCELLEME:
                        Console.Clear();
                        foreach (string eleman in ogrenci_bilgileri)
                        {
                            Console.WriteLine(eleman);
                        }
                        Console.WriteLine("Hangi bilgiyi güncelleyeceksiniz?");
                        Console.WriteLine("1-Telefon no");
                        Console.WriteLine("2-Adres");
                        string guncelleme = Convert.ToString(Console.ReadKey().KeyChar);
                        if (guncelleme == "1")
                        {
                            Console.Clear();
                            Console.Write("Telefon no giriniz?");
                            ogrenci_bilgileri[4] = "Telefon no :" + Console.ReadLine();
                            System.IO.File.WriteAllLines(ogrenci_hedef_yolu, ogrenci_bilgileri);
                            Console.Clear();
                            Console.WriteLine("Telefon no bilgisi güncellenmiştir.");
                            foreach (string eleman in ogrenci_bilgileri)
                            {
                                Console.WriteLine(eleman);
                            }
                            Console.WriteLine("Başka bilgi güncellenecekmi? (e vaya h)");
                            string guncelleme_devam = Convert.ToString(Console.ReadKey().Key);
                        YANLIS:
                            if (guncelleme_devam == "E")
                            {
                                goto GUNCELLEME;
                            }
                            else if (guncelleme_devam == "H")
                            {
                                goto BASADON;
                            }
                            else
                            {
                                Console.Clear();
                                Console.Write("Yanlış seçim");
                                goto YANLIS;
                            }
                        }
                        if (guncelleme == "2")
                        {
                            Console.Clear();
                            Console.Write("Adres giriniz?");
                            ogrenci_bilgileri[5] = "Adres :" + Console.ReadLine();
                            System.IO.File.WriteAllLines(ogrenci_hedef_yolu, ogrenci_bilgileri);
                            Console.Write("Adres bilgisi güncellenmiştir.");
                            foreach (string eleman in ogrenci_bilgileri)
                            {
                                Console.WriteLine(eleman);
                            }
                            Console.Write("Başka bilgi güncellenecekmi? (e vaya h)");
                            string guncelleme_devam = Convert.ToString(Console.ReadKey().Key);
                        YANLIS:
                            if (guncelleme_devam == "E")
                            {
                                goto GUNCELLEME;
                            }
                            else if (guncelleme_devam == "H")
                            {
                                goto BASADON;
                            }
                            else
                            {
                                Console.Clear();
                                Console.Write("Yanlış seçim");
                                goto YANLIS;
                            }
                        }
                    }

                    break;
                case "3":
                    Console.Clear();
                    Console.Write("Öğrenci numarasını giriniz?");
                    ogrno = Console.ReadLine();
                    System.IO.DirectoryInfo silinecek_klasor_bilgisi = new DirectoryInfo("C:\\Okul");
                    System.IO.FileInfo[] dosya_dizisi = silinecek_klasor_bilgisi.GetFiles(ogrno + ".txt", System.IO.SearchOption.AllDirectories);
                    int bulunan_dosya_adeti = dosya_dizisi.Length;
                    if (bulunan_dosya_adeti > 0)
                    {
                        string silinecek_dosya_yolu = dosya_dizisi[0].DirectoryName;
                        string[] klasor_dizisi = silinecek_dosya_yolu.Split('\\');
                    SILMEONAYI:
                        Console.Clear();
                        Console.WriteLine("{0} sınıfta {1} numaralı öğrenciyi silmek istedinize eminmisiniz? (e veya h)", klasor_dizisi[2], ogrno);
                        string silme_onayi = Convert.ToString(Console.ReadKey().Key);
                        if (silme_onayi == "E")
                        {
                            Console.Clear();
                            System.IO.Directory.Delete(silinecek_dosya_yolu, true);
                            Console.WriteLine("{0} Sınıfında {1} numaralı öğrenci silinmiştir.", klasor_dizisi[2], ogrno);
                            Console.ReadKey();
                            goto BASADON;
                        }
                        else if (silme_onayi == "H")
                        {
                            Console.Clear();
                            Console.WriteLine("Silme işlemi iptal edilmiştir.");
                            Console.ReadKey();
                            goto BASADON;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Yanlış menu seçimi yapdiniz!");
                            Console.ReadKey();
                            goto SILMEONAYI;
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.Write("Okulda {0} numaralı öğrenci yoktur!", ogrno);
                        Console.ReadKey();
                        goto BASADON;
                    }
                    break;
                case "4":
                    Console.Clear();
                    Console.Write("Öğrenci numarasını giriniz :");
                    ogrno = Console.ReadLine();
                    System.IO.DirectoryInfo tasinacak_klasor_bilgisi = new DirectoryInfo("C:\\Okul");
                    System.IO.FileInfo[] bulunan_dosyalar = tasinacak_klasor_bilgisi.GetFiles(ogrno + ".txt", System.IO.SearchOption.AllDirectories);
                    int bulunan_dosyalar_adeti = bulunan_dosyalar.Length;
                    if (bulunan_dosyalar_adeti > 0)
                    {
                        Console.Clear();
                        string tasinacak_klasor_yolu = bulunan_dosyalar[0].DirectoryName;
                        string[] klasorler = tasinacak_klasor_yolu.Split("\\");
                        Console.Write("{0} Sınıfındaki öğrenci hangi sınıfa taşınacak ?", klasorler[2]);
                        string tasinacak_klasor_adi = Console.ReadLine();
                        if (System.IO.Directory.Exists("C:\\Okul" + "\\" + tasinacak_klasor_adi) == true)
                        {
                            string hedef_klasor_yolu = @"C:\Okul" + "\\" + tasinacak_klasor_adi + "\\" + ogrno;
                            System.IO.Directory.Move(tasinacak_klasor_yolu, hedef_klasor_yolu);
                            Console.Clear();
                            Console.Write("{0} Sınıfında {1} numaralı öğrenci, {2} sınıfına taşınmıştır.", klasorler[2], ogrno, tasinacak_klasor_adi);
                            Console.ReadKey();
                            goto BASADON;
                        }
                        else
                        {
                            Console.Clear();
                            Console.Write("Okulda {0} Adında sınıf yoktur!", tasinacak_klasor_adi);
                            Console.ReadKey();
                            goto BASADON;
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.Write("Okulda {0} numaralı öğrenci yoktur!", ogrno);
                        Console.ReadKey();
                        goto BASADON;
                    }
                    break;
                case "5":
                    Environment.Exit(0);
                    break;
                default:
                    Console.Clear();
                    Console.Write("Yanlış menu seçimi yapdınız!");
                    Console.ReadKey();
                    goto BASADON;
                    break;
            }
        }
    }
}
