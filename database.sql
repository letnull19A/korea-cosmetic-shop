--
-- userQL database dump
--

-- Dumped from database version 14.5
-- Dumped by pg_dump version 14.5

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: categories; Type: TABLE; Schema: public; Owner: user
--

CREATE TABLE public.categories (
    id uuid NOT NULL,
    name text NOT NULL
);


ALTER TABLE public.categories OWNER TO user;

--
-- Name: favorites; Type: TABLE; Schema: public; Owner: user
--

CREATE TABLE public.favorites (
    id uuid NOT NULL,
    user_id uuid NOT NULL,
    product_id uuid NOT NULL,
    "UserDtosId" uuid,
    "ProductDtosId" uuid
);


ALTER TABLE public.favorites OWNER TO user;

--
-- Name: images; Type: TABLE; Schema: public; Owner: user
--

CREATE TABLE public.images (
    id uuid NOT NULL,
    file_name text NOT NULL
);


ALTER TABLE public.images OWNER TO user;

--
-- Name: payment_means; Type: TABLE; Schema: public; Owner: user
--

CREATE TABLE public.payment_means (
    id uuid NOT NULL,
    user_id uuid NOT NULL,
    system text NOT NULL,
    card_number text NOT NULL,
    user_name text NOT NULL,
    "UserDtoId" uuid
);


ALTER TABLE public.payment_means OWNER TO user;

--
-- Name: products; Type: TABLE; Schema: public; Owner: user
--

CREATE TABLE public.products (
    id uuid NOT NULL,
    category_id uuid NOT NULL,
    name text NOT NULL,
    description text NOT NULL,
    wrapper_image text NOT NULL,
    composition text NOT NULL,
    price double precision NOT NULL,
    count integer NOT NULL
);


ALTER TABLE public.products OWNER TO user;

--
-- Name: products_and_images; Type: TABLE; Schema: public; Owner: user
--

CREATE TABLE public.products_and_images (
    id uuid NOT NULL,
    image_id uuid NOT NULL,
    product_id uuid NOT NULL,
    "ProductDtoId" uuid,
    "ImageDtoId" uuid
);


ALTER TABLE public.products_and_images OWNER TO user;

--
-- Name: reviews; Type: TABLE; Schema: public; Owner: user
--

CREATE TABLE public.reviews (
    id uuid NOT NULL,
    user_id uuid NOT NULL,
    product_id uuid NOT NULL,
    message text NOT NULL,
    rating integer NOT NULL,
    date timestamp with time zone NOT NULL
);


ALTER TABLE public.reviews OWNER TO user;

--
-- Name: users; Type: TABLE; Schema: public; Owner: user
--

CREATE TABLE public.users (
    id uuid NOT NULL,
    name text NOT NULL,
    surname text NOT NULL,
    "fatherName" text,
    login text NOT NULL,
    email text NOT NULL,
    password text NOT NULL,
    phone text NOT NULL
);


ALTER TABLE public.users OWNER TO user;

--
-- Data for Name: categories; Type: TABLE DATA; Schema: public; Owner: user
--

INSERT INTO public.categories VALUES ('56531f68-25e6-4306-ac8e-bf01b18ad83e', 'Уход за проблемной кожей');


--
-- Data for Name: favorites; Type: TABLE DATA; Schema: public; Owner: user
--



--
-- Data for Name: images; Type: TABLE DATA; Schema: public; Owner: user
--

INSERT INTO public.images VALUES ('0009ec21-c797-429a-ad65-c87ee650800b', 'мапа1.png');
INSERT INTO public.images VALUES ('902132ee-b41d-4900-8fdb-8387c3b7ab53', 'мапа1.png');


--
-- Data for Name: payment_means; Type: TABLE DATA; Schema: public; Owner: user
--



--
-- Data for Name: products; Type: TABLE DATA; Schema: public; Owner: user
--

INSERT INTO public.products VALUES ('9b897254-deae-46d6-ae6b-4fce669c78d7', '56531f68-25e6-4306-ac8e-bf01b18ad83e', 'hfgjhfgshsfhfh', 'fjhsfgjhfgshss', 'мапа1.png', 'tjhs\FGSHGHSFH', 1, 1);


--
-- Data for Name: products_and_images; Type: TABLE DATA; Schema: public; Owner: user
--

INSERT INTO public.products_and_images VALUES ('24556bd3-eaf3-44b4-91b8-21b224cb55de', '902132ee-b41d-4900-8fdb-8387c3b7ab53', '9b897254-deae-46d6-ae6b-4fce669c78d7', NULL, NULL);


--
-- Data for Name: reviews; Type: TABLE DATA; Schema: public; Owner: user
--



--
-- Data for Name: users; Type: TABLE DATA; Schema: public; Owner: user
--

INSERT INTO public.users VALUES ('b939f1fb-917c-459d-bd1b-b0260fb28969', 'Алексей', 'Алексеев', 'Алексеевич', 'alexx1224', 'alexvolkovdd@gmail.com', '11111111', '89053483364');


--
-- Name: categories PK_categories; Type: CONSTRAINT; Schema: public; Owner: user
--

ALTER TABLE ONLY public.categories
    ADD CONSTRAINT "PK_categories" PRIMARY KEY (id);


--
-- Name: favorites PK_favorites; Type: CONSTRAINT; Schema: public; Owner: user
--

ALTER TABLE ONLY public.favorites
    ADD CONSTRAINT "PK_favorites" PRIMARY KEY (id);


--
-- Name: images PK_images; Type: CONSTRAINT; Schema: public; Owner: user
--

ALTER TABLE ONLY public.images
    ADD CONSTRAINT "PK_images" PRIMARY KEY (id);


--
-- Name: payment_means PK_payment_means; Type: CONSTRAINT; Schema: public; Owner: user
--

ALTER TABLE ONLY public.payment_means
    ADD CONSTRAINT "PK_payment_means" PRIMARY KEY (id);


--
-- Name: products PK_products; Type: CONSTRAINT; Schema: public; Owner: user
--

ALTER TABLE ONLY public.products
    ADD CONSTRAINT "PK_products" PRIMARY KEY (id);


--
-- Name: products_and_images PK_products_and_images; Type: CONSTRAINT; Schema: public; Owner: user
--

ALTER TABLE ONLY public.products_and_images
    ADD CONSTRAINT "PK_products_and_images" PRIMARY KEY (id);


--
-- Name: reviews PK_reviews; Type: CONSTRAINT; Schema: public; Owner: user
--

ALTER TABLE ONLY public.reviews
    ADD CONSTRAINT "PK_reviews" PRIMARY KEY (id);


--
-- Name: users PK_users; Type: CONSTRAINT; Schema: public; Owner: user
--

ALTER TABLE ONLY public.users
    ADD CONSTRAINT "PK_users" PRIMARY KEY (id);


--
-- Name: IX_favorites_ProductDtosId; Type: INDEX; Schema: public; Owner: user
--

CREATE INDEX "IX_favorites_ProductDtosId" ON public.favorites USING btree ("ProductDtosId");


--
-- Name: IX_favorites_UserDtosId; Type: INDEX; Schema: public; Owner: user
--

CREATE INDEX "IX_favorites_UserDtosId" ON public.favorites USING btree ("UserDtosId");


--
-- Name: IX_payment_means_UserDtoId; Type: INDEX; Schema: public; Owner: user
--

CREATE INDEX "IX_payment_means_UserDtoId" ON public.payment_means USING btree ("UserDtoId");


--
-- Name: IX_products_and_images_ImageDtoId; Type: INDEX; Schema: public; Owner: user
--

CREATE INDEX "IX_products_and_images_ImageDtoId" ON public.products_and_images USING btree ("ImageDtoId");


--
-- Name: IX_products_and_images_ProductDtoId; Type: INDEX; Schema: public; Owner: user
--

CREATE INDEX "IX_products_and_images_ProductDtoId" ON public.products_and_images USING btree ("ProductDtoId");


--
-- Name: IX_products_category_id; Type: INDEX; Schema: public; Owner: user
--

CREATE INDEX "IX_products_category_id" ON public.products USING btree (category_id);


--
-- Name: favorites FK_favorites_products_ProductDtosId; Type: FK CONSTRAINT; Schema: public; Owner: user
--

ALTER TABLE ONLY public.favorites
    ADD CONSTRAINT "FK_favorites_products_ProductDtosId" FOREIGN KEY ("ProductDtosId") REFERENCES public.products(id);


--
-- Name: favorites FK_favorites_users_UserDtosId; Type: FK CONSTRAINT; Schema: public; Owner: user
--

ALTER TABLE ONLY public.favorites
    ADD CONSTRAINT "FK_favorites_users_UserDtosId" FOREIGN KEY ("UserDtosId") REFERENCES public.users(id);


--
-- Name: payment_means FK_payment_means_users_UserDtoId; Type: FK CONSTRAINT; Schema: public; Owner: user
--

ALTER TABLE ONLY public.payment_means
    ADD CONSTRAINT "FK_payment_means_users_UserDtoId" FOREIGN KEY ("UserDtoId") REFERENCES public.users(id);


--
-- Name: products_and_images FK_products_and_images_images_ImageDtoId; Type: FK CONSTRAINT; Schema: public; Owner: user
--

ALTER TABLE ONLY public.products_and_images
    ADD CONSTRAINT "FK_products_and_images_images_ImageDtoId" FOREIGN KEY ("ImageDtoId") REFERENCES public.images(id);


--
-- Name: products_and_images FK_products_and_images_products_ProductDtoId; Type: FK CONSTRAINT; Schema: public; Owner: user
--

ALTER TABLE ONLY public.products_and_images
    ADD CONSTRAINT "FK_products_and_images_products_ProductDtoId" FOREIGN KEY ("ProductDtoId") REFERENCES public.products(id);


--
-- Name: products FK_products_categories_category_id; Type: FK CONSTRAINT; Schema: public; Owner: user
--

ALTER TABLE ONLY public.products
    ADD CONSTRAINT "FK_products_categories_category_id" FOREIGN KEY (category_id) REFERENCES public.categories(id) ON DELETE CASCADE;


--
-- userQL database dump complete
--
