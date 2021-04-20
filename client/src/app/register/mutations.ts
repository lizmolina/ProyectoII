import gql from 'graphql-tag';

export const CREATE_USER = gql`
mutation($input: UserInput!){
    createUser(input:$input){
      id
      name
      lastName
      phone
      email
      password
    
    }
  }

`;


