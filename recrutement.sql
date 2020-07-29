

                        
            create database recutement;
          
            CREATE TABLE region
            (
                id_region INT identity PRIMARY KEY,
                nom_region VARCHAR (250) UNIQUE NOT NULL,
            )
        
                  -- je cree la table qui associe la region et l'entreprise parce que une ou plusieurs entreprises peux exister dans une meme region ou bien une region peux avoir une ou plusieurs entreprises la relation (n,n) on doit aussi associer avec les tables servivice et poste qui au table region et entreprise
           
                     
            CREATE TABLE service
            (
                id_service INT identity PRIMARY KEY,
               
                nom_service VARCHAR(255) unique NOT NULL,
                
            )
            
           
            
            CREATE TABLE poste 
            (
                id_poste INT identity PRIMARY KEY,              
                nom_poste VARCHAR (250) unique NOT NULL,
         
            )
            
            CREATE TABLE association_au_region
            (
                id_ass INT identity primary key ,
                id_region INT  NOT NULL,
                id_service INT  NOT NULL,
                id_poste INT NOT NULL,
                date_associe VARCHAR(50) unique not null              
            )
            
             ALTER TABLE association_au_region ADD CONSTRAINT fk_reg FOREIGN KEY(id_region) REFERENCES region(id_region);
            
            ALTER TABLE association_au_region ADD CONSTRAINT fk_serv FOREIGN KEY(id_service) REFERENCES service(id_service);
            
            ALTER TABLE association_au_region ADD CONSTRAINT fk_post FOREIGN KEY(id_poste) REFERENCES poste(id_poste);
            
            CREATE TABLE employer
            (
                id_employer INT identity PRIMARY KEY,
                id_ass INT NOT NULL,
                matricule VARCHAR(255) UNIQUE NOT NULL,
                nom VARCHAR (250) not null,
                prenom varchar(250) not null,
                profiles VARCHAR(250) NOT NULL,
                photo_empl image NOT NULL,
                date_naissance VARCHAR(30),
                lieu_naissance VARCHAR(100),
                mail VARCHAR (80),
                tel varchar (50),
                date_enreg varchar(50) unique not null 
                
            )
            

            
            ALTER TABLE employer ADD CONSTRAINT fk_assoc_empl FOREIGN KEY(id_ass) REFERENCES association_au_region(id_ass);
            
           CREATE TABLE utilisateur
            (
            id_utilisateur INT identity PRIMARY KEY,
            id_employer INT UNIQUE NOT NULL,
            nom_utilisateur varchar(255)  not null unique,
       		mot_de_passe VARCHAR(30) UNIQUE NOT NULL,
     		type_utilisateur varchar(30)NOT NULL ,
            date_ajout varchar(50) UNIQUE not null
                
            )
          --  CHECK (type_utilisateur IN('simple','admin','recruteur','publicitaire'))
            
           ALTER TABLE utilisateur ADD CONSTRAINT fk_empl FOREIGN KEY (id_employer) REFERENCES employer(id_employer);
            
           -- CREATE TABLE publicite_interne
          --  (
                
			--	id_publicite INT PRIMARY KEY identity,
		--		id_utilisateur int ,
		--		type_publicite varchar(30) NOT NULL CHECK (type_publicite IN ('simple','recrutement')),
		--		description_pub TEXT NOT NULL,
		--		masque int not null check(masque in (0,1)),
		--		lien_site text DEFAULT NULL,
		--		date_creation varchar(50) unique not null 
		
          --  )
            
       --     ALTER TABLE publicite_interne ADD CONSTRAINT fk_user FOREIGN KEY (id_utilisateur) REFERENCES utilisateur(id_utilisateur);
	  
      --      CREATE TABLE vu_publicite_interne
       --    (
      --          id_vu INT PRIMARY KEY identity,
	--			id_utilisateur int,
      --          id_employer INT NOT NULL,
      --        id_publicite INT NOT NULL,
     --           date_vu varchar(50) unique not null
                
      --      )
            
     --       ALTER TABLE vu_publicite_interne ADD CONSTRAINT fk_user_vu FOREIGN KEY (id_utilisateur) REFERENCES utilisateur(id_utilisateur);
            
      --      ALTER TABLE vu_publicite_interne ADD CONSTRAINT fk_pub_vu FOREIGN KEY (id_publicite) REFERENCES publicite_interne(id_publicite);
            

            
        --    CREATE TABLE commentaire 
       --     (
                
        --        id_commentaire INT PRIMARY KEY identity,
         --       id_vu INT NOT NULL,
         --       commentaire TEXT NOT NULL,
        --        date_commentaire varchar(50) not null unique
          --  )

         --   ALTER TABLE commentaire ADD CONSTRAINT fk_user_com FOREIGN KEY (id_vu) REFERENCES vu_publicite_interne(id_vu);
            
            
            CREATE TABLE publicite_externe
            (
                id_pub_externe INT PRIMARY KEY identity,
                id_utilisateur INT NOT NULL,
                 titre varchar(255)not null ,
                description_pub text NOT NULL,
     			typ_pub varchar(50) NOT NULL,
                valide varchar(50) NOT NULL,
                date_pub_externe varchar(50) unique not null
               
            )
           
		--	alter table publicite_externe add constraint ck_pub  CHECK (typ_pub IN ('Recrutement','Autre'));
			 
		--	alter table publicite_externe add constraint ck_valide CHECK (valide IN ('oui','no','masqer'));
            
            ALTER TABLE publicite_externe ADD CONSTRAINT fk_user_recr FOREIGN KEY (id_utilisateur) REFERENCES utilisateur(id_utilisateur);

            CREATE TABLE postuler_externe
            (
                id_postuler_externe INT PRIMARY KEY identity,
                id_pub_externe INT NOT NULL,
			
                nom VARCHAR (255) NOT NULL,
                prenom VARCHAR (255) NOT NULL,
                mail VARCHAR(255) ,
                tel VARCHAR(60) NOT NULL,
                my_document text NOT NULL,
                photo image NOT NULL,
                date_postuler varchar(50)not null
            )
            
            
            ALTER TABLE postuler_externe ADD CONSTRAINT fk_pub_recr FOREIGN KEY (id_pub_externe) REFERENCES publicite_externe(id_pub_externe);
            
            ALTER TABLE postuler_externe ADD CONSTRAINT fk_ass_post FOREIGN KEY (id_ass) REFERENCES association_au_region(id_ass);
            
            
            CREATE TABLE recruter_externe
            (
                id_recruter INT PRIMARY KEY identity,
                id_postuler_externe INT UNIQUE NOT NULL,
                date_recruter varchar(50) unique not null 
            )
            
            ALTER TABLE recruter_externe ADD CONSTRAINT fk_recr FOREIGN KEY (id_postuler_externe) REFERENCES postuler_externe(id_postuler_externe);
            
            
 --           CREATE TABLE postuler_interne
  --          (
  --              id_postuler_interne INT PRIMARY KEY identity,
  --              id_employer_postuler INT NOT NULL,
  --              id_ass_nouv INT NOT NULL,
  --              dossier_demande varchar(255),
 --               date_postuler_interne varchar(50) unique not null 
  --          )
            
  --          ALTER TABLE postuler_interne ADD CONSTRAINT fk_post_int FOREIGN KEY (id_employer_postuler) REFERENCES employer(id_employer);
            
  --          ALTER TABLE postuler_interne ADD CONSTRAINT fk_nouv_ass_nouv FOREIGN KEY (id_ass_nouv) REFERENCES association_au_region(id_ass);
            
  --          CREATE TABLE recruter_empl_interne
  --          (
  --              id_recruter_interne INT PRIMARY KEY identity,
  --              id_postuler_interne INT  NOT NULL,
--				id_utilisateur int not null,
 --               id_denier_ass INT NOT NULL,
 --               date_recruter_interne varchar(50) unique not null 
 --           )
            
 --           ALTER TABLE recruter_empl_interne ADD CONSTRAINT fk_recr_int FOREIGN KEY (id_postuler_interne) REFERENCES postuler_interne(id_postuler_interne);
            
 --           ALTER TABLE recruter_empl_interne ADD CONSTRAINT fk_dern_ass FOREIGN KEY (id_postuler_interne) REFERENCES association_au_region(id_ass);
            
 --           CREATE TABLE mutation
  --          (
  --              id_mutation INT PRIMARY KEY identity,
  --             id_utilisateur_fait INT NOT NULL,
  --              id_employer_changer INT NOT NULL,
   --             id_denier_ass INT NOT NULL,
 --                date_changer varchar(50) unique not null 
   --          )
--
  --          ALTER TABLE mutation ADD CONSTRAINT fk_user_fait_int FOREIGN KEY (id_utilisateur_fait) REFERENCES utilisateur(id_utilisateur);
            
   --         ALTER TABLE mutation ADD CONSTRAINT fk_idempl_chang_int FOREIGN KEY (id_employer_changer) REFERENCES employer(id_employer);
            
   --         ALTER TABLE mutation ADD CONSTRAINT fk_dern_ass_mut FOREIGN KEY (id_denier_ass) REFERENCES association_au_region(id_ass);
          
            
            
            
            
