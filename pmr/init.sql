create table genres
(
	id bigint generated always as identity primary key,
	name varchar(50) not null,
	created_at timestamp without time zone default now(),
	updated_at timestamp without time zone default now()
);

create table companies
(
	id bigint generated always as identity primary key,
	name varchar(50) not null,
	image_path text not null,
	created_at timestamp without time zone default now(),
	updated_at timestamp without time zone default now()
);

create table countries
(
	id bigint generated always as identity primary key,
	name varchar(50) not null,
	created_at timestamp without time zone default now(),
	updated_at timestamp without time zone default now()
);

create table languages
(
	id bigint generated always as identity primary key,
	name varchar(50) not null,
	created_at timestamp without time zone default now(),
	updated_at timestamp without time zone default now()
);

create table titles
(
	id bigint generated always as identity primary key,
	name varchar(50) not null,
	created_at timestamp without time zone default now(),
	updated_at timestamp without time zone default now()
);

create table users
(
	id bigint generated always as identity primary key,
	first_name varchar(50) not null,
	last_name varchar(50) not null,
	image_path text not null,
	phone_number varchar(50) not null,
	phone_number_confirmed bool not null,
	password_hash text not null,
	salt text not null,
	identity_role text not null,
	created_at timestamp without time zone default now(),
	updated_at timestamp without time zone default now()
);

create table movies
(
	id bigint generated always as identity primary key,
	genre_id bigint references genres(id),
	title_id bigint references titles(id),
	company_id bigint references companies(id),
	language_id bigint references languages(id),
	country_id bigint references countries(id),
	name varchar(50) not null,
	movie_path text not null,
	image_path text not null,
	trailer_path text not null,
	description text not null,
	rating real not null,
	release_year int not null,
	duration varchar(5) not null,
	created_at timestamp without time zone default now(),
	updated_at timestamp without time zone default now()
);

ALTER DATABASE "filmland-db"
SET TIMEZONE TO 'Asia/Tashkent';