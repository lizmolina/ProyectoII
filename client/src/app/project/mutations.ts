import gql from 'graphql-tag';

export const CREATE_PROJECT = gql`
    mutation($project: ProjectInput!) {
        createProject(input: $project) {
            id
            title
            description
        }
    }
`;

export const UPDATE_PROJECT = gql`
    mutation($id: ID!, $project: ProjectInput!) {
        updateProject(id: $id, input: $project) {
            id
            title
            description
        }
    }
`;

export const DELETE_PROJECT = gql`
    mutation($id: ID!) {
        deleteProject(id: $id) {
            id
        }
    }
`;