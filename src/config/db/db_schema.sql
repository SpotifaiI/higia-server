create table
  public.task
(
  task_id            uuid                     not null default gen_random_uuid(),
  created_at         timestamp with time zone not null default now(),
  initial_coordinate character varying null,
  end_coordinate     character varying null,
  description        character varying null,
  observation        character varying null,
  initial_date       date null,
  end_date           date null,
  play_date          date null,
  constraint Task_pkey primary key (task_id)
) tablespace pg_default;

create table
  public.user
(
  user_id    uuid                     not null default gen_random_uuid(),
  created_at timestamp with time zone not null default now(),
  phone      character varying null,
  birthday   date null,
  name       character varying null,
  email      character varying null,
  admin      boolean null,
  constraint User_pkey primary key (user_id)
) tablespace pg_default;

create table
  public.user_task
(
  "user" uuid not null,
  task   uuid null,
  constraint user_task_task_fkey foreign key (task) references task (task_id),
  constraint user_task_user_fkey foreign key ("user") references "user" (user_id)
) tablespace pg_default;