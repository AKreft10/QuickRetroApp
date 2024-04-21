export interface RetrospectiveColumn {
    name: string;
    cards: string[];
  }
  
  export interface RetrospectiveBoard {
    columns: RetrospectiveColumn[];
  }