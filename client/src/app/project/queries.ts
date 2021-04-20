import gql from 'graphql-tag';

export const PROJECT_QUERY = gql`
    query($title: String, $description: String ) {
        projectsAll(title: $title, description: $description) {
            id
            title
            description
        }
    }
`;