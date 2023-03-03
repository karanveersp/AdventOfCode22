import util

def score_for_hands():
    plays = [p.replace("\n", "").split(" ") for p in util.get_data_lines(2)]
    rock, paper, scissors = 1, 2, 3
    opp_decoder = {"A": rock, "B": paper, "C": scissors}
    my_decoder = {"X": rock, "Y": paper, "Z": scissors}
    beat = {rock: paper, paper: scissors, scissors: rock}
    loss_modifier, draw_modifier, win_modifier = 0, 3, 6

    def round(opp_encoded_hand, my_encoded_hand) -> int: 
        my_hand = my_decoder[my_encoded_hand]
        opp_hand = opp_decoder[opp_encoded_hand]
     
        if my_hand == beat[opp_hand]:
            return my_hand + win_modifier
        elif opp_hand == beat[my_hand]:
            return my_hand + loss_modifier
        else:
            return my_hand + draw_modifier  
    
    scores = [round(opp_hand, my_hand) for opp_hand, my_hand in plays]
    print(sum(scores))

def score_for_desired_outcome():
    plays = [p.replace("\n", "").split(" ") for p in util.get_data_lines(2)]
    rock, paper, scissors = 1, 2, 3
    opp_decoder = {"A": rock, "B": paper, "C": scissors}
    outcome_decoder = {"X": "lose", "Y": "draw", "Z": "win"}
    to_winning_hand = {rock: paper, paper: scissors, scissors: rock}
    to_losing_hand = {v: k for k, v in to_winning_hand.items()}
    loss_modifier, draw_modifier, win_modifier = 0, 3, 6

    def round(opp_encoded_hand, encoded_outcome) -> int: 
        opp_hand = opp_decoder[opp_encoded_hand] 
        outcome = outcome_decoder[encoded_outcome] 
        if outcome == "win":
            winning_hand = to_winning_hand[opp_hand]
            return winning_hand + win_modifier
        elif outcome == "lose":
            losing_hand = to_losing_hand[opp_hand]
            return losing_hand + loss_modifier
        else:
            return opp_hand + draw_modifier  
    
    scores = [round(opp_hand, outcome) for opp_hand, outcome in plays]
    print(sum(scores))

score_for_hands()
score_for_desired_outcome()
        

    