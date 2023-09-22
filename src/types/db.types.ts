export type Json =
  | string
  | number
  | boolean
  | null
  | { [key: string]: Json | undefined }
  | Json[]

export interface Database {
  public: {
    Tables: {
      task: {
        Row: {
          created_at: string
          description: string | null
          end_coordinate: string | null
          end_date: string | null
          initial_coordinate: string | null
          initial_date: string | null
          observation: string | null
          play_date: string | null
          task_id: string
        }
        Insert: {
          created_at?: string
          description?: string | null
          end_coordinate?: string | null
          end_date?: string | null
          initial_coordinate?: string | null
          initial_date?: string | null
          observation?: string | null
          play_date?: string | null
          task_id?: string
        }
        Update: {
          created_at?: string
          description?: string | null
          end_coordinate?: string | null
          end_date?: string | null
          initial_coordinate?: string | null
          initial_date?: string | null
          observation?: string | null
          play_date?: string | null
          task_id?: string
        }
        Relationships: []
      }
      user: {
        Row: {
          admin: boolean | null
          birthday: string | null
          created_at: string
          email: string | null
          name: string | null
          phone: string | null
          user_id: string
        }
        Insert: {
          admin?: boolean | null
          birthday?: string | null
          created_at?: string
          email?: string | null
          name?: string | null
          phone?: string | null
          user_id?: string
        }
        Update: {
          admin?: boolean | null
          birthday?: string | null
          created_at?: string
          email?: string | null
          name?: string | null
          phone?: string | null
          user_id?: string
        }
        Relationships: []
      }
      user_task: {
        Row: {
          task: string | null
          user: string
        }
        Insert: {
          task?: string | null
          user: string
        }
        Update: {
          task?: string | null
          user?: string
        }
        Relationships: [
          {
            foreignKeyName: "user_task_task_fkey"
            columns: ["task"]
            referencedRelation: "task"
            referencedColumns: ["task_id"]
          },
          {
            foreignKeyName: "user_task_user_fkey"
            columns: ["user"]
            referencedRelation: "user"
            referencedColumns: ["user_id"]
          }
        ]
      }
    }
    Views: {
      [_ in never]: never
    }
    Functions: {
      [_ in never]: never
    }
    Enums: {
      [_ in never]: never
    }
    CompositeTypes: {
      [_ in never]: never
    }
  }
}
