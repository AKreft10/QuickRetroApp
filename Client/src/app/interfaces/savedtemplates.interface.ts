export interface SavedTemplates {
    id: string
    name: string
    backgroundUrl: string
    createdAt: string
    columns: Column[]
  }
  
  export interface Column {
    id: string
    name: string
  }