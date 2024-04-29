export interface RetrospectiveColumn {
    name: string;
    cards: string[];
    id: string | undefined;
  }
  
  export interface RetrospectiveBoard {
    columns: RetrospectiveColumn[];
  }