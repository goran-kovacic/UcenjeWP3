use master;
go
drop database if exists printapphib;
go

create database printapphib;
go
use printapphib;

CREATE TABLE materials (
  id int not null primary key identity(1,1),
  bottomExposure decimal(38,2) DEFAULT NULL,
  bottomLiftDistance int DEFAULT NULL,
  bottomLiftSpeed decimal(38,2) DEFAULT NULL,
  bottomRetractSpeed decimal(38,2) DEFAULT NULL,
  calibratedExposure decimal(38,2) DEFAULT NULL,
  costPerUnit decimal(38,2) DEFAULT NULL,
  layerHeight decimal(38,2) DEFAULT NULL,
  liftDistance int DEFAULT NULL,
  liftSpeed decimal(38,2) DEFAULT NULL,
  lightOffDelay decimal(38,2) DEFAULT NULL,
  manufacturer varchar(255) NOT NULL,
  materialName varchar(255) NOT NULL,
  retractSpeed decimal(38,2) DEFAULT NULL
 );

 CREATE TABLE printers (
  id int not null primary key identity(1,1),
  fepCount int DEFAULT NULL,
  manufacturer varchar(255) NOT NULL,
  printerName varchar(255) NOT NULL,
  printerTime int DEFAULT NULL
  );

  CREATE TABLE projects (
  id int not null primary key identity(1,1),
  completionDate datetime DEFAULT NULL,
  creationDate datetime DEFAULT NULL,
  isCompleted tinyint DEFAULT NULL,
  projectDescription varchar(255) DEFAULT NULL,
  projectName varchar(255) NOT NULL,
  totalCost decimal(38,2) DEFAULT NULL,
  totalPrintCount int DEFAULT NULL,
  totalPrintTime int DEFAULT NULL
  );

CREATE TABLE users (
  id int not null primary key identity(1,1),
  userName varchar(255) NOT NULL,
  userPassword varchar(255) NOT NULL
  );

  CREATE TABLE parts (
  id int not null primary key identity(1,1),
  cost decimal(38,2) DEFAULT NULL,
  partName varchar(255) NOT NULL,
  printTime int DEFAULT NULL,
  project_id int DEFAULT NULL,
  foreign key (project_id) references projects (id)
  );

  CREATE TABLE printfiles (
  id int not null primary key identity(1,1),
  fileComment varchar(255) DEFAULT NULL,
  filePath varchar(255) DEFAULT NULL,
  fileType varchar(255) DEFAULT NULL,
  fileVersion int DEFAULT NULL,
  part int DEFAULT NULL,
  foreign key (part) references parts (id)
  );

  CREATE TABLE printjobs (
  id int not null primary key identity(1,1),
  cost decimal(38,2) DEFAULT NULL,
  printTime int DEFAULT NULL,
  result bit NOT NULL,
  volume decimal(38,2) DEFAULT NULL,
  material int DEFAULT NULL,
  part_id int DEFAULT NULL,
  printer_id int DEFAULT NULL,
  foreign key (material) references materials (id),
  foreign key (part_id) references parts (id),
  foreign key (printer_id) references printers(id)
  );

  INSERT INTO users (userName,userPassword) VALUES
	 ('admin','$argon2i$v=19$m=65536,t=10,p=1$RbXTY6TH4mj6RZ9CFkOyow$i2AsmP9HXFnY6QgX0GJldM3EIu8H5KzVWiMncOwHOAE');

  INSERT INTO dbo.materials (bottomExposure,bottomLiftDistance,bottomLiftSpeed,bottomRetractSpeed,calibratedExposure,costPerUnit,layerHeight,liftDistance,liftSpeed,lightOffDelay,manufacturer,materialName,retractSpeed) VALUES
	 (15.00,4,3.00,2.00,3.00,46.00,25.00,7,4.00,1.00,'Earth','Q',3.00),
	 (10.00,7,4.00,3.00,3.00,69.00,17.00,7,7.00,1.00,'Saturn','Betazoid',9.00),
	 (46.00,4,3.00,1.00,3.00,49.00,83.00,8,1.00,1.00,'Mercury','Jem''Hadar',4.00),
	 (31.00,4,3.00,8.00,3.00,51.00,46.00,4,7.00,0.00,'Saturn','Ferengi',9.00),
	 (30.00,5,3.00,3.00,4.00,89.00,34.00,7,7.00,0.00,'Mars','Vorta',9.00);
 
 INSERT INTO dbo.printers (fepCount,manufacturer,printerName,printerTime) VALUES
	 (3,'Neptune','Maltz',453),
	 (11,'Earth','Q',1600),
	 (8,'Mercury','Ru''afo',1188),
	 (8,'Saturn','Maltz',1720),
	 (0,'Neptune','Gorn',0);

INSERT INTO dbo.projects (completionDate,creationDate,isCompleted,projectDescription,projectName,totalCost,totalPrintCount,totalPrintTime) VALUES
	 ('2023-03-02','2023-04-25',1,'Ad debitis dolor enim voluptatem at. Enim ut cupiditate repudiandae velit sit. Quo possimus ipsa voluptas sunt. Illum voluptatem ducimus aut nam. Aspernatur ducimus est aliquam.','The Briar Patch',0.00,0,0),
	 ('2023-11-02','2023-10-31',0,'Perferendis est blanditiis et dolorem. Sapiente et esse blanditiis. Dolorum mollitia nemo quo. Qui sunt nisi dolorum possimus totam. Eos tenetur autem eos voluptate dolor qui. Atque officia aut provident iste voluptatibus sequi dolores.','Gamma Quadrant',34.83,2,461),
	 ('2023-09-15','2023-10-30',0,'Quis omnis fugit autem vitae quos. Vel est non ullam quidem expedita reprehenderit. Alias est voluptas et dolores. Optio aut consequatur ad est. Odit sint molestiae vel.','Thalos VII',44.34,1,550),
	 ('2023-10-23','2023-04-25',0,'Nostrum dolor et. Suscipit dolorem veritatis culpa. Repellendus nihil odio. Iusto odio in officiis velit deleniti. Voluptatem temporibus velit ipsa ut. Quam fuga asperiores omnis.','Deep Space Nine',57.27,2,560),
	 ('2023-04-18','2023-01-12',1,'Et nulla qui provident. Placeat odio ipsa praesentium eos quasi. Sunt est earum consequuntur qui autem quidem neque. Deserunt illum aut iusto consequatur. Quibusdam magnam est neque ut et.','Gamma Quadrant',36.59,1,483),
	 ('2023-11-13','2023-09-15',0,'Ad possimus exercitationem assumenda qui nostrum. Sit voluptatem soluta eos enim minima fugit. Praesentium dignissimos repellendus beatae corporis. Ut quis nobis dolores ipsum molestiae. Possimus debitis repellat consequuntur labore qui qui ut.','Wolf 359',3.77,1,64),
	 ('2023-03-21','2023-11-24',0,'Voluptatem at modi. Consequuntur rerum non asperiores natus asperiores ut quia. Adipisci commodi aliquid et nemo illo blanditiis. Quidem mollitia qui voluptatum. Et velit ab. Deserunt et dicta vero velit alias distinctio porro.','Qo''noS',40.24,1,400),
	 ('2023-03-10','2023-08-11',0,'Ut praesentium quia occaecati qui a neque placeat. Rem non ut. Nulla quidem dolorem iusto vel. Tempora hic mollitia odio sed numquam est ullam. Aut doloremque ut. Sed amet sunt commodi repellat earum. Et a velit in aut non.','Deep Space Nine',0.00,0,0),
	 ('2023-01-17','2023-05-29',0,'Exercitationem sunt et modi. Unde corrupti est tenetur in cupiditate sit. Quod qui quo. Pariatur eum sit voluptas. Non ut expedita optio eos architecto et dicta.','Bajor',27.98,2,225),
	 ('2023-05-04','2023-06-24',1,'In odio laudantium illum excepturi praesentium delectus. Veniam eius consequatur quibusdam necessitatibus voluptatem. Ut vitae deserunt id quam nisi voluptas. Est quo aperiam alias doloribus perspiciatis voluptates. Et porro quae officiis sed doloremque.','Alpha Quadrant',0.00,0,0);

INSERT INTO dbo.parts (cost,partName,printTime,project_id) VALUES
	 (0.00,'Data',0,6),
	 (22.98,'Jonathan Archer',244,4),
	 (34.29,'Travis Mayweather',316,4),
	 (3.77,'Hoshi Sato',64,6),
	 (0.00,'Harry Kim',0,5),
	 (0.00,'Jonathan Archer',0,5),
	 (40.24,'Travis Mayweather',400,7),
	 (0.00,'Deanna Troi',0,6),
	 (0.00,'Odo',0,9),
	 (16.35,'Seven of Nine',105,9);
INSERT INTO dbo.parts (cost,partName,printTime,project_id) VALUES
	 (17.34,'Montgomery Scott',225,2),
	 (0.00,'Beverly Crusher',0,8),
	 (0.00,'Jonathan Archer',0,5),
	 (44.34,'Malcolm Reed',550,3),
	 (0.00,'Geordi La Forge',0,6),
	 (36.59,'Jadzia Dax',483,5),
	 (17.49,'Malcolm Reed',236,2),
	 (11.63,'Pavel Chekov',120,9),
	 (0.00,'Leonard McCoy',0,6),
	 (0.00,'Natasha Yar',0,9);


	 INSERT INTO dbo.printfiles (fileComment,filePath,fileType,fileVersion,part) VALUES
	 ('Doloremque est iusto. Voluptatum odio temporibus omnis dolore qui ratione sit. Fugit autem tenetur id et. Nisi quisquam id ab neque itaque. Error mollitia sit fugiat eveniet. Iure non praesentium animi eaque. Consequatur et et blanditiis aut consequuntur ','C:\\ea_perspiciatis\\hic.csv','Test_File_Type',1,16),
	 ('Earum ut at odio dignissimos. Necessitatibus et magnam. Tempora quas rerum qui. Esse labore repudiandae earum qui repellendus soluta. Tempora nisi accusantium ut est accusamus soluta.','C:\\magni_qui\\aut.ppt','Test_File_Type',1,9),
	 ('Rem fugit nihil iusto quis. Quo hic iste consequatur non possimus. Fugiat fuga sequi pariatur voluptatem. Nemo enim eos voluptatem et. Est aspernatur impedit eaque non. Dolor nesciunt autem et voluptatem.','C:\\accusantium_accusamus\\quo.xlsx','Test_File_Type',1,12),
	 ('Odit cum similique qui facilis voluptas autem. Ut reiciendis illum. Neque inventore temporibus nesciunt laborum. Omnis vitae laudantium. Excepturi molestiae impedit magni eos culpa quam.','C:\\facilis_et\\similique.ods','Test_File_Type',1,10),
	 ('Et beatae cumque nostrum et aliquid sunt necessitatibus. Ea laboriosam alias. Enim voluptates iusto porro. Odio aut et dolorum. Autem qui deleniti saepe vel.','C:\\eveniet_est\\fugit.odp','Test_File_Type',1,2),
	 ('Facere sunt voluptatem ab illo. Eaque ut impedit voluptate sit et. Ad quaerat rerum ipsam. Cumque numquam illo et expedita voluptas consectetur sunt. Adipisci ipsa quas ullam quia libero sed id. Aliquam magnam cupiditate. Eveniet quas ut dolor voluptatem ','C:\\velit_consequatur\\quasi.xlsx','Test_File_Type',1,11),
	 ('Deserunt eum accusantium dolore velit adipisci aut voluptas. Officiis voluptates dolorem deserunt ab est illo necessitatibus. Consequatur dolorum ratione repellendus aut vero dolor. Voluptatem blanditiis provident sapiente temporibus. Autem voluptatem ea ','C:\\dolorum_error\\ex.xlsx','Test_File_Type',1,7),
	 ('Qui eius aspernatur. Iure modi minus quae error eos. Eaque est possimus quam et. Sit illum eos. Aut facilis aut suscipit. Ut quaerat quia eius voluptate veritatis voluptatibus. Tenetur laborum dolore eos fugiat optio.','C:\\perspiciatis_voluptas\\aliquam.pages','Test_File_Type',1,17),
	 ('Quibusdam mollitia exercitationem qui id corporis esse animi. Dicta itaque iste. Facere dolorum quam et nesciunt unde a. Officia dicta alias quas rerum at in. In sequi eius quas. Amet architecto laborum laborum sed.','C:\\quasi_odio\\distinctio.gif','Test_File_Type',1,11),
	 ('Doloremque provident sunt sunt veniam perferendis eos quia. Et minima autem eveniet occaecati voluptates. Esse veritatis dolore aut placeat aut quia rerum. Neque vel voluptates enim sed. Delectus ipsam qui accusamus. Aut a ut ut earum ut animi natus. Quib','C:\\nobis_qui\\molestiae.odp','Test_File_Type',1,11);
INSERT INTO dbo.printfiles (fileComment,filePath,fileType,fileVersion,part) VALUES
	 ('Et aut deleniti voluptatibus temporibus eos. Soluta tempore sapiente aut quod molestiae mollitia quibusdam. Cupiditate et incidunt. Officiis et nobis fugit magnam ut quia incidunt. Maiores officiis modi et blanditiis ratione dolores. Et alias quis quo vol','C:\\aut_modi\\odit.ods','Test_File_Type',1,11),
	 ('Repellat aut nisi. Aut quia quis velit a accusantium aspernatur odio. Officiis sunt ad. Qui quaerat in odio. Voluptatem et sapiente sint facere aut ut. Corrupti consequatur sed nam. Qui exercitationem voluptates dolores deleniti rem.','C:\\quia_et\\reiciendis.pages','Test_File_Type',1,13),
	 ('Eligendi est beatae quam. Officia aperiam vitae corrupti. Magnam natus aut provident eveniet fugiat est blanditiis. Odit est rerum sint repellat ut. At necessitatibus sequi ea ea reiciendis mollitia. Explicabo in ullam.','C:\\quidem_laudantium\\et.ods','Test_File_Type',1,3),
	 ('Velit placeat at repellat voluptatem eligendi illo. Aperiam nobis blanditiis autem dignissimos quibusdam. Et magni hic molestiae porro assumenda totam sequi. Atque tenetur reprehenderit. Commodi rerum aliquid molestias et voluptas quia.','C:\\placeat_quae\\rerum.js','Test_File_Type',1,16),
	 ('Perferendis deserunt nemo et. Rerum voluptates vitae accusamus consequatur. Itaque error ipsum possimus et dolorum et. Ipsum facilis eum atque perferendis ex. Expedita consequatur iure libero officia. Nemo voluptates sapiente doloribus. Nihil hic consequu','C:\\voluptatem_sint\\impedit.avi','Test_File_Type',1,1),
	 ('Quibusdam earum consequatur ea eum. Velit corrupti rem impedit iusto quae. Aut illum exercitationem saepe. Nihil ea est eius voluptas vero. Vel voluptatem ut possimus. In laudantium facere illum neque.','C:\\recusandae_unde\\sint.ppt','Test_File_Type',1,10),
	 ('Pariatur nulla molestias eum aut possimus dolore dignissimos. Quas similique voluptatem doloremque exercitationem ex quidem numquam. Consequuntur ipsam beatae. Architecto et id iure perspiciatis eligendi. Pariatur laborum culpa et est totam impedit id.','C:\\aperiam_est\\est.wav','Test_File_Type',1,17),
	 ('Qui dignissimos quos. Animi aliquam et ea. Non dolorum odio et. Consequatur aspernatur quibusdam ipsam voluptatem animi. Consequatur eos modi natus dolorem unde voluptatibus sapiente. Facilis assumenda distinctio amet eaque quo illo. Qui placeat quam laud','C:\\provident_quos\\at.wav','Test_File_Type',1,4),
	 ('Nam distinctio ut facilis esse in. In aut et nihil iure tempora. Consequatur ea vel totam autem. Excepturi et et doloremque. Ut perspiciatis ullam.','C:\\temporibus_ipsum\\facilis.jpg','Test_File_Type',1,13),
	 ('Ea excepturi consequatur fugit quis excepturi quo. Esse eligendi aut. Nihil excepturi veritatis labore. Blanditiis et recusandae voluptatum beatae omnis. Quia distinctio ullam.','C:\\necessitatibus_dignissimos\\sequi.png','Test_File_Type',1,18);
INSERT INTO dbo.printfiles (fileComment,filePath,fileType,fileVersion,part) VALUES
	 ('Quae magni corporis libero qui debitis nemo. Doloribus architecto earum cumque rem. Perferendis quis tenetur quisquam voluptatem sed repellendus consequatur. Voluptatem ex adipisci repudiandae dolorem exercitationem natus fugit. Ea ut veniam.','C:\\ut_consequatur\\recusandae.docx','Test_File_Type',1,18),
	 ('Eos omnis rem esse quia tempora ipsam. Id explicabo modi. Aut consequatur corporis deleniti omnis aut ullam amet. Deleniti maxime enim enim dicta reprehenderit. Quod quos quisquam quae assumenda est suscipit dolores. Quasi et est iste nesciunt cupiditate ','C:\\id_maiores\\voluptatibus.tiff','Test_File_Type',1,18),
	 ('Voluptatum vero eum quo. Quod voluptatem odio repellendus laborum accusantium. Temporibus expedita sit dolorem aut aut molestiae. Mollitia ducimus vitae molestiae eaque dolorem dolorum. Odit aliquid quia ut. Nihil aliquam enim et et alias vel. Molestias c','C:\\quidem_consequatur\\illo.mp4','Test_File_Type',1,9),
	 ('Voluptas minima aut. Similique odio sapiente a esse dolor quam. Ea quod rerum ducimus dolorem possimus. Occaecati quia est excepturi ab veritatis fugit. Saepe deserunt aperiam inventore quidem voluptatum quidem autem. Quas libero voluptatum ut.','C:\\aliquid_qui\\aut.xls','Test_File_Type',1,4),
	 ('Molestiae earum minima inventore nihil accusantium veritatis illo. Sit praesentium laboriosam ab consequatur tenetur in deleniti. Dolor ea ea quod sed qui. Dolores quis mollitia asperiores quis labore aperiam deserunt. Sint temporibus et similique quibusd','C:\\vel_quisquam\\expedita.flac','Test_File_Type',1,16),
	 ('Porro et tempora molestias beatae architecto. Incidunt illum repellat odit voluptatem veniam similique placeat. Saepe quasi sapiente et ipsum qui sunt impedit. Ullam nemo excepturi error tempora distinctio ut voluptas. Ducimus culpa harum voluptatem et qu','C:\\soluta_voluptates\\ea.jpg','Test_File_Type',1,12),
	 ('Temporibus laudantium voluptate ea. Illo cumque omnis. Aut deserunt voluptatum saepe rem et ut. Quae consectetur repudiandae quaerat. Eum et quasi vel. Distinctio aut possimus.','C:\\dolores_occaecati\\culpa.css','Test_File_Type',1,15),
	 ('Non cumque assumenda est reprehenderit veniam. Quis facilis consequuntur iste. Ipsam qui autem nam. Esse ut sunt vero omnis est eligendi veniam. Voluptas id et omnis voluptates ipsa et reprehenderit. Incidunt est consequuntur sint est. Sequi totam et.','C:\\dolorem_ut\\aut.webm','Test_File_Type',1,4),
	 ('Quos ut sit quia odit itaque aut. Eos enim odio itaque tenetur. Expedita rerum sit. Culpa veritatis voluptas consectetur tempore et. Officiis labore praesentium dignissimos consectetur non et ipsam.','C:\\aperiam_voluptatum\\iste.doc','Test_File_Type',1,3),
	 ('Excepturi quod ipsam ut fugiat sunt ea dolores. Molestiae ut qui quis mollitia ipsam sunt quisquam. Minima at voluptate tempore repudiandae reiciendis doloribus. Nostrum ratione sit asperiores laudantium ad qui temporibus. Cum consequatur laboriosam ipsum','C:\\quisquam_est\\corporis.gif','Test_File_Type',1,18);
INSERT INTO dbo.printfiles (fileComment,filePath,fileType,fileVersion,part) VALUES
	 ('Et et ut. Atque voluptatem est occaecati. Ut quas placeat sed omnis consequatur. Quis et cupiditate non. Esse esse qui.','C:\\quisquam_excepturi\\quod.mp3','Test_File_Type',1,10),
	 ('Fugiat dolorum odio numquam nisi. Aut ut doloribus velit aperiam inventore. Voluptatem exercitationem non. Omnis doloremque placeat rerum dolore. Est et ipsa. Nemo rerum occaecati quaerat quis pariatur.','C:\\occaecati_adipisci\\vitae.key','Test_File_Type',1,16),
	 ('Blanditiis qui consequatur perferendis illum illum fugit. Quia et est dolor beatae architecto voluptas. Voluptatem optio cupiditate quod. Quam sapiente laboriosam ad et doloremque et. Aut voluptatibus non non. Ut vel aperiam. Voluptatibus nisi est officii','C:\\ut_animi\\aut.bmp','Test_File_Type',1,13),
	 ('Quis in molestiae omnis occaecati cum autem. Pariatur beatae blanditiis. Facilis minima velit eos quia nobis at. Praesentium libero ut laboriosam qui. Ratione blanditiis modi doloremque pariatur.','C:\\est_ipsa\\voluptatum.png','Test_File_Type',1,15),
	 ('Commodi autem quod quo qui sit. Inventore et esse consequatur sequi quasi iure ut. Dolorem voluptas quae molestiae ut reprehenderit in hic. Cum velit ea modi qui ea aut totam. Sequi aliquid quia quae exercitationem dolor. Aliquid veritatis occaecati cupid','C:\\doloremque_atque\\rerum.csv','Test_File_Type',1,14),
	 ('Omnis magni amet odit neque distinctio omnis occaecati. Consequatur consequatur cumque ab rerum aliquam earum vero. Odit hic et nihil delectus. Suscipit quia est. Voluptate expedita sed et qui aut nihil.','C:\\in_placeat\\sunt.mp3','Test_File_Type',1,7),
	 ('Velit incidunt eum. Tempora animi exercitationem laudantium nesciunt. Consequatur incidunt doloremque eum. Dolor consequatur suscipit rem eaque enim quo. Pariatur dolor id esse odio laudantium qui. Beatae earum in aspernatur rem. Maxime odit autem illum v','C:\\mollitia_sit\\et.txt','Test_File_Type',1,15),
	 ('Sit commodi consectetur rem quidem eligendi voluptas. Et facilis modi perspiciatis minus recusandae. Aliquid aut libero quia sed aut inventore labore. Dolor quisquam quibusdam. Magnam non quasi. Cum perferendis animi voluptatem magni et magnam.','C:\\ipsa_maxime\\repellat.flac','Test_File_Type',1,11),
	 ('Totam et accusantium et et et ut fugiat. Ut iusto dolorem neque saepe ab. Ut consequatur quia rerum dicta. Vel est neque. Neque quo aut voluptatem voluptatem dolor quia porro. Aut eveniet voluptatem officia. Voluptatem aut quos quas.','C:\\omnis_recusandae\\qui.tiff','Test_File_Type',1,18),
	 ('Et architecto id ut earum ab aliquam aut. Repellat consequuntur voluptas. Dolorem quae aut deleniti. Ut earum doloribus. Deserunt nobis iusto. Officia quisquam porro sed architecto. Sapiente vel dolor est.','C:\\dolores_vel\\aut.flac','Test_File_Type',1,15);
INSERT INTO dbo.printfiles (fileComment,filePath,fileType,fileVersion,part) VALUES
	 ('Aperiam aut quia non. Repellendus ad non. Quibusdam impedit perferendis. Nisi aut quia quis minima. Quo neque maiores repellendus doloribus.','C:\\nesciunt_possimus\\mollitia.pages','Test_File_Type',1,3),
	 ('Et voluptatibus facere quis doloribus. Sit beatae iusto ut assumenda. Enim qui consequatur. Molestiae eveniet tenetur eveniet qui consequatur ab consequuntur. Neque alias et doloremque debitis voluptatibus. Quia natus et.','C:\\suscipit_possimus\\reiciendis.mov','Test_File_Type',1,18),
	 ('Incidunt expedita qui quo quis occaecati. Consequatur recusandae ullam delectus quos a distinctio. Perspiciatis eveniet dolor eligendi in. Voluptas recusandae qui dolor quidem inventore. Suscipit laudantium soluta. Occaecati nostrum sed quo quidem in ea n','C:\\quae_dolorem\\deserunt.txt','Test_File_Type',1,4),
	 ('Sit beatae eum quaerat deleniti cum consequatur debitis. Ut maiores qui. Sunt id molestiae velit dolores aut dignissimos consequatur. Aliquam sit optio quas enim nemo veritatis. Sunt quod explicabo ut nostrum nesciunt.','C:\\et_aspernatur\\quas.txt','Test_File_Type',1,10),
	 ('Alias odit reprehenderit vero minus eum. Autem quis ab similique quibusdam. Ut quo officiis velit maxime assumenda. Ut dicta provident. Saepe consequatur quia aut explicabo et libero quis.','C:\\id_occaecati\\est.bmp','Test_File_Type',1,4),
	 ('Eos velit voluptatibus. In sit aut nemo consequatur fugiat doloremque voluptas. Voluptas accusamus repellendus saepe voluptatem non eaque. Nostrum consectetur sequi perferendis fuga sit dolorem. Tempora voluptatum in sint sit sunt quia ut.','C:\\quo_nihil\\possimus.key','Test_File_Type',1,15),
	 ('Libero deserunt facilis odio. Facere quas optio debitis et sed voluptatem. Minima ipsam perferendis quibusdam eligendi. Dolorem eaque adipisci et libero ipsa. Ut odio quo. Ab debitis voluptatem veniam culpa ut. Tempora optio in.','C:\\corporis_quibusdam\\illum.docx','Test_File_Type',1,6),
	 ('Maiores quo ab laboriosam. Atque maiores molestiae error. Expedita laudantium aliquid. In commodi pariatur. Est aut excepturi inventore incidunt magni sunt. Qui consequatur ut placeat impedit facilis.','C:\\error_quia\\in.pdf','Test_File_Type',1,10),
	 ('Voluptas modi aut a magnam est. Aut veritatis et sit ex a quibusdam temporibus. Sunt consectetur sed at eos impedit alias. Et adipisci ipsam nam. Assumenda ut recusandae quaerat voluptas.','C:\\voluptas_iusto\\neque.mov','Test_File_Type',1,4),
	 ('Nulla doloribus aliquam sapiente animi dolorum nobis. Rem nemo in qui assumenda aspernatur sunt molestiae. Et laudantium quidem nam perspiciatis alias incidunt doloremque. Vero voluptatum corrupti quia repudiandae sunt et. Eaque ducimus eligendi sed. Simi','C:\\deserunt_blanditiis\\magnam.json','Test_File_Type',1,18);
INSERT INTO dbo.printfiles (fileComment,filePath,fileType,fileVersion,part) VALUES
	 ('In dignissimos est quia ducimus. Repudiandae earum est veniam quod aut perferendis. Aut molestias animi officia quis rem. Voluptates occaecati velit. Libero labore voluptas ipsam. Laudantium error sunt officiis eligendi autem sint sint. Blanditiis ipsam a','C:\\voluptatum_itaque\\excepturi.docx','Test_File_Type',1,7),
	 ('Incidunt dolorum ea hic. Aliquam dolorum tempore et vel iste sit aut. Saepe maxime voluptas eius. Explicabo eaque consequatur amet. Odio qui eveniet fugit debitis suscipit. Aliquam dolor voluptas nihil excepturi.','C:\\nobis_doloribus\\suscipit.mov','Test_File_Type',1,6),
	 ('Tenetur unde aut dolore sit. Non doloribus et eos necessitatibus voluptatem veniam labore. Aliquam eaque nihil ipsum quo sapiente aliquid. Quaerat optio dolore molestias tempora doloribus repudiandae tenetur. Et omnis occaecati eum. Est est ab sed sit ips','C:\\corrupti_cum\\exercitationem.doc','Test_File_Type',1,11),
	 ('Aliquam voluptas quam adipisci. Dolores quam veritatis. Est quidem dolor et et. Blanditiis et sit et. Dolorem quia vel ex et occaecati molestiae. Voluptatum eum eaque suscipit nam. Aut distinctio ea dolorem quibusdam ut.','C:\\reiciendis_animi\\et.odp','Test_File_Type',1,16),
	 ('Soluta odio sunt et. Architecto dolore quasi id. Non autem et delectus fugit qui consequuntur sunt. Iusto rerum nemo temporibus sit. Sint expedita in accusantium.','C:\\placeat_et\\beatae.odp','Test_File_Type',1,11),
	 ('Non et beatae corporis cupiditate voluptas. Sit molestiae quia officia. Ad doloribus et. Quas saepe molestias blanditiis est et. Qui reiciendis adipisci.','C:\\dolores_quasi\\modi.jpeg','Test_File_Type',1,6),
	 ('Est dolores sit unde sit id. Est magnam non eum perferendis quasi esse. A soluta molestiae sequi ratione repellendus dolorem ducimus. Dolorum velit porro ratione alias. Ipsam iusto error.','C:\\voluptatem_reiciendis\\impedit.webm','Test_File_Type',1,3),
	 ('Tempore id et at rerum quo sit corrupti. Officiis quam odit in dolorum quia aperiam esse. Possimus ut et. Dolore et eveniet at odio recusandae minima. Maxime odio non tempore iure. Aut velit aut inventore.','C:\\ipsa_iure\\nisi.mov','Test_File_Type',1,6),
	 ('Iste repudiandae quas iste velit illo quidem eos. Praesentium nostrum veniam omnis modi. Expedita est odio. Ut neque ab suscipit esse totam et. Quo mollitia accusamus quia saepe eum quo.','C:\\cum_quaerat\\rerum.json','Test_File_Type',1,10),
	 ('Odio consectetur accusamus exercitationem et sed voluptas sapiente. Quia eos reiciendis tempore soluta vel. Aut sint et rerum alias. Fuga at eum et sunt aut. Dolor ducimus minus expedita repellat aut. Pariatur fugit vero numquam.','C:\\iusto_eos\\earum.jpg','Test_File_Type',1,14);


	 INSERT INTO dbo.printjobs (cost,printTime,result,volume,material,part_id,printer_id) VALUES
	 (17.34,225,1,340.00,4,11,4),
	 (22.98,244,1,469.00,3,2,4),
	 (22.75,178,1,446.00,4,7,3),
	 (17.49,236,1,343.00,4,17,4),
	 (11.63,120,1,228.00,4,18,3),
	 (16.83,187,1,330.00,4,3,2),
	 (17.49,222,1,357.00,3,7,2),
	 (3.93,181,0,77.00,4,11,2),
	 (9.64,107,0,189.00,4,17,2),
	 (17.99,267,0,391.00,1,1,3);
INSERT INTO dbo.printjobs (cost,printTime,result,volume,material,part_id,printer_id) VALUES
	 (12.93,240,1,281.00,1,16,2),
	 (9.74,264,1,191.00,4,14,4),
	 (23.66,243,1,464.00,4,16,1),
	 (20.61,135,0,448.00,1,9,4),
	 (17.20,85,0,351.00,3,3,3),
	 (16.35,105,1,237.00,2,10,2),
	 (9.07,246,0,185.00,3,11,4),
	 (26.15,152,0,379.00,2,8,3),
	 (8.52,58,0,167.00,4,4,2),
	 (8.00,62,0,116.00,2,6,3);
INSERT INTO dbo.printjobs (cost,printTime,result,volume,material,part_id,printer_id) VALUES
	 (12.08,200,0,175.00,2,12,4),
	 (3.77,64,1,82.00,1,4,2),
	 (6.66,84,0,136.00,3,17,1),
	 (26.63,126,0,386.00,2,5,1),
	 (23.46,170,0,340.00,2,9,4),
	 (17.46,129,1,253.00,2,3,2),
	 (28.43,91,1,412.00,2,14,2),
	 (17.04,129,0,247.00,2,18,3),
	 (6.17,195,1,121.00,4,14,3),
	 (22.85,216,0,448.00,4,8,2);




